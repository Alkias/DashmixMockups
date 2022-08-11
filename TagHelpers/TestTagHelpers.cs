using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;


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
    /// A Bootstrap modal dialog
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

        public string Type { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
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

            var templateLargeTop =
$@"<div class='modal-dialog modal-lg' role='document'>
    <div class='modal-content'>
        <div class='block block-themed block-transparent mb-0'>
        
            <div class='block-header bg-primary-dark'>
	            <h3 class='block-title'>{Title}</h3>
	            <div class='block-options'>
		            <button type='button' class='btn-block-option' data-dismiss='modal' aria-label='Close'>
			            <i class='fa fa-fw fa-times'></i>
		            </button>
	            </div>
            </div>
           
            <div class='block-content'>
                <div class='block-content block-content-full'>";

            var templateDefault =
$@"<div class='modal-dialog modal-dialog-centered' role='document'>
    <div class='modal-content'>
            <div class='block-header'>
	            <h5 class='block-title'>{Title}</h5>
		            <button type='button' class='btn-block-option' data-dismiss='modal' aria-label='Close'>
			            <i class='fa fa-fw fa-times'></i>
		            </button>
            </div>
           
            <div class='modal-body pb-1'>";

            var templateCenter =
$@"<div class='modal-dialog modal-dialog-centered' role='document'>
    <div class='modal-content'>
        <div class='block block-themed block-transparent mb-0'>
        
            <div class='block-header bg-primary-dark'>
	            <h3 class='block-title'>{Title}</h3>
	            <div class='block-options'>
		            <button type='button' class='btn-block-option' data-dismiss='modal' aria-label='Close'>
			            <i class='fa fa-fw fa-times'></i>
		            </button>
	            </div>
            </div>
           
            <div class='block-content'>";

            if (Type=="default")
                output.Content.AppendHtml(templateDefault);
            else if(Type=="center")
                output.Content.AppendHtml(templateCenter);
            else
                output.Content.AppendHtml(templateLargeTop);

            if (modalContext.Body != null) {
                output.Content.AppendHtml(modalContext.Body);
            }

            if (Type != "default" && Type != "center")
                output.Content.AppendHtml("</div>"); // block-content block-content-full

            output.Content.AppendHtml("</div>"); // block-content

            if (modalContext.Footer != null) {
                if (Type != "default") 
                    output.Content.AppendHtml("<div class='block-content block-content-full text-right bg-light'>");
                else
                    output.Content.AppendHtml("<div class='modal-footer'>");
                output.Content.AppendHtml(modalContext.Footer);
                output.Content.AppendHtml("</div>");
            }

            if (Type != "default")
                output.Content.AppendHtml("</div>"); //block block-themed
            output.Content.AppendHtml("</div>"); //modal-content
            output.Content.AppendHtml("</div>"); //modal-dialog modal-lg
        }
    }

    /// <summary>
    /// The modal-body portion of a Bootstrap modal dialog
    /// </summary>
    [HtmlTargetElement("modal-body", ParentTag = "modal")]
    public class ModalBodyTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();
            var modalContext = (ModalContext)context.Items[typeof(ModalTagHelper)];
            modalContext.Body = childContent;
            output.SuppressOutput();
        }
    }

    /// <summary>
    /// The modal-footer portion of Bootstrap modal dialog
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


        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (ShowDismiss) {
                output.PreContent.AppendFormat(@"<button type='button' class='btn-sm btn-light' data-dismiss='modal'>{0}</button>", DismissText);
            }
            var childContent = await output.GetChildContentAsync();

            var footerContent = new DefaultTagHelperContent();

            if (ShowDismiss) 
                footerContent.AppendFormat(@"<button type='button' class='btn-sm btn-light' data-dismiss='modal'>{0}</button> ", DismissText);
            footerContent.AppendFormat(@"<button type='button' class='btn btn-sm btn-primary' data-dismiss='modal'>{0}</button>", OkText);
            
            footerContent.AppendHtml(childContent);
            var modalContext = (ModalContext)context.Items[typeof(ModalTagHelper)];
            modalContext.Footer = footerContent;
            output.SuppressOutput();
        }
    }
}
