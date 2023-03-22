#DropDB E2096
#Application E2096Win
#Application E2096Web

;Begin Test ListView
*FillRecord
 IdentityColumns = Name
 IdentityRow = 'HyperLinkDemoObject1'
 Columns = Url
 Values = Error
 
#IfDef E2096Win
*Action Save
*Action Refresh
#EndIf
#IfDef E2096Web
*ExecuteTableAction
 Name = 'HyperLinkDemoObject1'
 InlineUpdate = ''
;Here validation error should occur and it needs to be canceled.
*ExecuteTableAction
 Name = 'HyperLinkDemoObject1'
 InlineCancel = ''
#EndIf

*CheckTable
 Columns = Url
 Row = support@devexpress.com

*FillRecord
 IdentityColumns = Name
 IdentityRow = 'HyperLinkDemoObject1'
 Columns = Url
 Values = test@mail.com

#IfDef E2096Win
*Action Save
*Action Refresh
#EndIf
#IfDef E2096Web
*ExecuteTableAction
 Name = 'HyperLinkDemoObject1'
 InlineUpdate = ''
!ExecuteTableAction
 Name = 'HyperLinkDemoObject1'
 InlineCancel = ''
#EndIf

*CheckTable
 Columns = Url
 Row = test@mail.com

*FillRecord
 IdentityColumns = Name
 IdentityRow = 'HyperLinkDemoObject1'
 Columns = Url
 Values = www.google.com

#IfDef E2096Win
*Action Save
*Action Refresh
#EndIf
#IfDef E2096Web
*ExecuteTableAction
 Name = 'HyperLinkDemoObject1'
 InlineUpdate = ''
!ExecuteTableAction
 Name = 'HyperLinkDemoObject1'
 InlineCancel = ''
#EndIf

*CheckTable
 Columns = Url
 Row = www.google.com
;End Test ListView


*Action New

;#IfDef E2096Win
;Begin Test DetailView
*FillForm
 Url = error
*Action Save
*CheckValidationResult
 Message = Problems were detected during data validation.*
 Info = Invalid URL or email
*OptionalAction Close

*FillForm
 Url = test@mail.com
*Action Save

*FillForm
 Url = www.google.com

*Action Save
;End Test DetailView
;#EndIf