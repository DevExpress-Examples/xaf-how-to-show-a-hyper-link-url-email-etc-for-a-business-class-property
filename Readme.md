<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128593398/18.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2096)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# How to show a hyper link (URL, email, etc.) for a business class property


<p><strong>Scenario<br></strong>The following basic functionality is implemented in the <em>HyperLinkPropertyEditor.Win and </em> <em>HyperLinkPropertyEditor.Web</em> modules:</p>
<p><strong>1.</strong> Custom <a href="https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument113097">PropertyEditor</a> classes for WinForms and ASP.NET  are based on the <u><a href="http://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraEditorsHyperLinkEdittopic">HyperLinkEdit</a></u> and <a href="http://documentation.devexpress.com/#AspNet/clsDevExpressWebASPxEditorsASPxHyperLinktopic">ASPxHyperLink</a>  controls that can be used for representing object fields, containing email address, a URL in the UI.<br> <strong>2.</strong> To validate an input, a combined RexEx mask is used in both ListView and DetailView of WinForms and ASP.NET applications. The default regular expression is the following:<br> (((http|https|ftp)\://)?[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;amp;%\$#\=~])*)|([a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6})<br> You can use it as is or modify it per your specific needs. Look for <a href="http://msdn.microsoft.com/en-us/library/2k3te2cs%28VS.80%29.aspx"><u>Regular Expressions</u></a> in MSDN for more information on how to do this. <br> <strong>3.</strong> The default email client or browser window is opened after a single click on the hyperlink if it represents a valid email, web address or phone number. For end-users convenience, in DetailView of WinForms projects, a double-click is necessary to be able to easily edit the field.<br><br><br><br><strong>Steps to implement</strong></p>
<p><strong>1.</strong> Copy and include the <em>HyperLinkPropertyEditor.Web or </em> <em>HyperLinkPropertyEditor.Win</em> projects into your solution and make sure it is built successfully. Feel free to modify the settings of the underlying controls according to their documentation to better meet your business needs, e.g. provide a custom display text instead of the raw URL via the <a href="https://documentation.devexpress.com/WindowsForms/DevExpressXtraEditorsRepositoryRepositoryItemHyperLinkEdit_Captiontopic.aspx">RepositoryItemHyperLinkEdit.Caption</a> and <a href="https://documentation.devexpress.com/AspNet/DevExpressWebASPxHyperLink_Texttopic.aspx">ASPxHyperLink.Text</a> options.</p>
<p><strong>2.</strong> Invoke the Application Designer for the <em>YourSolutionName/WinApplication.xx</em> file by double-clicking it in Solution Explorer. Invoke the Toolbox (Alt+X+T) and then drag & drop the <em>HyperLinkPropertyEditorWindowsFormsModule</em> component into the modules list on the left.</p>
<p><strong>3.</strong> Invoke the Application Designer for the <em>YourSolutionName/WebApplication.xx</em> file by double-clicking it in Solution Explorer. Invoke the Toolbox (Alt+X+T) and then drag & drop the <em>HyperLinkPropertyEditorAspNetModule</em> component into the modules list on the left.</p>
<p>
<p><strong>4.</strong> Define a string persistent property within your business class and decorate it with the <em>DevExpress.Persistent.Base.EditorAliasAttribute</em> passing the "HyperLinkStringPropertyEditor" string as a parameter. See the <em>E2096.Module\HyperLinkDemoObject.xx</em> file for an example.<br><br><br><strong>Frequently Asked Questions</strong><br><a href="https://www.devexpress.com/Support/Center/p/T483344">E2096 - How to specify a display text for the hyper link based on a different business class property</a></p>

<br/>


<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=xaf-how-to-show-a-hyper-link-url-email-etc-for-a-business-class-property&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=xaf-how-to-show-a-hyper-link-url-email-etc-for-a-business-class-property&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
