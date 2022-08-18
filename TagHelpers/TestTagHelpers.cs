using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;

//see: https://www.davepaquette.com/archive/2015/12/28/complex-custom-tag-helpers-in-mvc-6.aspx
//see: http://taghelpersamples.azurewebsites.net/Samples/ModalTagHelper
//see: https://github.com/dpaquette/TagHelperSamples

namespace DashmixMockups.TagHelpers
{
    public class ModalContext
    {
        public IHtmlContent Body { get; set; }
        public IHtmlContent Footer { get; set; }
    }

    /// <summary>
    /// A Bootstrap Dashmix modal dialog
    /// </summary>
    [RestrictChildren("modal-body", "modal-footer")]
    public class ModalTagHelper : TagHelper
    {
        /// <summary>
        /// The title of the modal
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The Id of the modal
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The type of modal
        /// Values: default, center or nothing
        /// </summary>
        public string Type { get; set; }

        public string Size { get; set; }

        public bool Center { get; set; }

        public override async Task ProcessAsync (TagHelperContext context, TagHelperOutput output) {
            var modalContext = new ModalContext();
            context.Items.Add(typeof(ModalTagHelper), modalContext);

            await output.GetChildContentAsync();

            output.TagName = "div";
            output.Attributes.SetAttribute("role", "dialog");
            output.Attributes.SetAttribute("id", Id);
            output.Attributes.SetAttribute("aria-labelledby", $"{context.UniqueId}Label");
            output.Attributes.SetAttribute("tabindex", "-1");
            output.Attributes.SetAttribute("aria-hidden", "true");
            var classNames = "modal";

            if (output.Attributes.ContainsName("class")) {
                classNames = $"{output.Attributes["class"].Value}";
            }

            output.Attributes.SetAttribute("class", classNames);

            var sizeAndCenter = string.IsNullOrWhiteSpace(Size) ? "" : $" {SetSize()}";
            sizeAndCenter += Center ? " modal-dialog-centered" : "";

            switch (Type) {
                case "default":
                    DefaultModal(modalContext, output, sizeAndCenter);
                    break;
                default:
                    NormalModal(modalContext, output, sizeAndCenter);
                    break;
            }
        }

        private string SetSize() {
            var size = "";
            switch (Size) {
                case "sm":
                    size = "modal-sm";
                    break;
                case "lg":
                    size = "modal-lg";
                    break;
                case "xl":
                    size = " modal-xl";
                    break;
                default:
                    size = "";
                    break;
            }

            return size;
        }

        private void DefaultModal (ModalContext modalContext, TagHelperOutput output, string sizeAndCenter) {
            var template =
                @$"<div class='modal-dialog{sizeAndCenter}' role='document'>
	    <div class='modal-content'>
		    <div class='modal-header'>
			    <h5 class='modal-title'>{Title}</h5>
			    <button type='button' class='btn-close' data-bs-dismiss='modal' aria-label='Close'></button>
		    </div>
		    <div class='modal-body pb-1'>";

            output.Content.AppendHtml(template);
            if (modalContext.Body != null) {
                output.Content.AppendHtml(modalContext.Body);
            }

            output.Content.AppendHtml("</div>"); //modal-body

            if (modalContext.Footer != null) {
                output.Content.AppendHtml("<div class='modal-footer'>");
                output.Content.AppendHtml(modalContext.Footer);
                output.Content.AppendHtml("</div>");
            }

            output.Content.AppendHtml("</div>"); //modal-content
            output.Content.AppendHtml("</div>"); //modal-dialog
        }

        private void NormalModal (ModalContext modalContext, TagHelperOutput output, string sizeAndCenter) {
            var template =
                @$"<div class='modal-dialog{sizeAndCenter}' role='document'>
            <div class='modal-content'>
                <div class='block block-rounded block-themed block-transparent mb-0'>
                    <div class='block-header bg-primary-dark'>
                        <h3 class='block-title'>{Title}</h3>
                        <div class='block-options'>
                            <button type='button' class='btn-block-option' data-bs-dismiss='modal' aria-label='Close'>
                                <i class='fa fa-fw fa-times'></i>
                            </button>
                        </div>
                    </div>
                    <div class='block-content'>";

            output.Content.AppendHtml(template);

            if (modalContext.Body != null) {
                output.Content.AppendHtml(modalContext.Body);
            }

            output.Content.AppendHtml("</div>"); //block-content

            if (modalContext.Footer != null) {
                output.Content.AppendHtml("<div class='modal-footer'>");
                output.Content.AppendHtml(modalContext.Footer);
                output.Content.AppendHtml("</div>");
            }

            output.Content.AppendHtml("</div>"); //block block-rounded
            output.Content.AppendHtml("</div>"); //modal-content
            output.Content.AppendHtml("</div>"); //modal-dialog
        }
    }

    /// <summary>
    /// The modal-body portion of a Bootstrap Dashmix modal dialog
    /// </summary>
    [HtmlTargetElement("modal-body", ParentTag = "modal")]
    public class ModalBodyTagHelper : TagHelper
    {
        public override async Task ProcessAsync (TagHelperContext context, TagHelperOutput output) {
            var childContent = await output.GetChildContentAsync();
            var modalContext = (ModalContext) context.Items[typeof(ModalTagHelper)];
            modalContext.Body = childContent;
            output.SuppressOutput();
        }
    }

    /// <summary>
    /// The modal-footer portion of Bootstrap Dashmix modal dialog
    /// </summary>
    [HtmlTargetElement("modal-footer", ParentTag = "modal")]
    public class ModalFooterTagHelper : TagHelper
    {
        /// <summary>
        /// Whether or not to show a button to dismiss the dialog.
        /// Default: <c>true</c>
        /// </summary>
        public bool ShowDismiss { get; set; } = true;

        /// <summary>
        /// The text to show on the Dismiss button
        /// Default: Cancel
        /// </summary>
        public string DismissText { get; set; } = "Cancel";

        public string OkText { get; set; } = "Done";

        public override async Task ProcessAsync (TagHelperContext context, TagHelperOutput output) {
            if (ShowDismiss) {
                output.PreContent.AppendFormat(@"<button type='button' class='btn btn-sm btn-alt-secondary' data-bs-dismiss='modal'>{0}</button>", DismissText);
            }

            var childContent = await output.GetChildContentAsync();

            var footerContent = new DefaultTagHelperContent();

            if (ShowDismiss)
                footerContent.AppendFormat(@"<button type='button' class='btn btn-sm btn-alt-secondary' data-bs-dismiss='modal'>{0}</button> ", DismissText);
            footerContent.AppendFormat(@"<button type='button' class='btn btn-sm btn-primary' data-bs-dismiss='modal'>{0}</button>", OkText);

            footerContent.AppendHtml(childContent);
            var modalContext = (ModalContext) context.Items[typeof(ModalTagHelper)];
            modalContext.Footer = footerContent;
            output.SuppressOutput();
        }
    }
}