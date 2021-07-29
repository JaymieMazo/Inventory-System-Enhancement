using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI_Inventory_System
{
    class Views
    {
        //view_ArticleSubcat
        //       SELECT dbo.tbl_Article.pk_Article_Id, dbo.tbl_Article.fk_Subcategory_Id, dbo.tbl_Category.Category_Name, dbo.tbl_Subcategory.Subcategory_Name, dbo.tbl_Subcategory.Subcategory_Code, dbo.tbl_Article.Article_Name,
        //                         dbo.tbl_Article.Article_Code
        //FROM            dbo.tbl_Subcategory INNER JOIN
        //                         dbo.tbl_Article ON dbo.tbl_Subcategory.pk_Subcategory_Id = dbo.tbl_Article.fk_Subcategory_Id INNER JOIN

        //                         dbo.tbl_Category ON dbo.tbl_Subcategory.fk_Category_Id = dbo.tbl_Category.pk_Category_Id

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        //view_CatSubcat
        //        SELECT dbo.tbl_Subcategory.pk_Subcategory_Id, dbo.tbl_Category.Category_Name, dbo.tbl_Subcategory.Subcategory_Name, dbo.tbl_Subcategory.Subcategory_Code
        //FROM            dbo.tbl_Category INNER JOIN
        //                         dbo.tbl_Subcategory ON dbo.tbl_Category.pk_Category_Id = dbo.tbl_Subcategory.fk_Category_Id

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        //view_CatSupplier
        //        SELECT dbo.tbl_Supplier.pk_Supplier_Id, dbo.tbl_Supplier.fk_Sup_Category_Id, dbo.tbl_Supplier_Category.Category_Name, dbo.tbl_Supplier.Supplier_Name, dbo.tbl_Supplier.Address, dbo.tbl_Supplier.Contact_No,
        //                         dbo.tbl_Supplier.Contact_Person, dbo.tbl_Supplier.TIN, dbo.tbl_Supplier.PHILGEPS_REG_No
        //FROM            dbo.tbl_Supplier INNER JOIN
        //                         dbo.tbl_Supplier_Category ON dbo.tbl_Supplier.fk_Sup_Category_Id = dbo.tbl_Supplier_Category.pk_Sup_Category_Id

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        //view_Disposal_Record
        //        SELECT dbo.view_Inventory_Details.pk_Id, dbo.view_Inventory_Details.Article_Name, dbo.view_Inventory_Details.Description, dbo.view_Inventory_Details.UOM, dbo.view_Inventory_Details.Unit_Cost,
        //                         dbo.view_Inventory_Details.Date_Acquired, dbo.view_Inventory_Details.Property_No, dbo.view_Inventory_Details.Serial_No, dbo.view_Inventory_Details.Fund_Cluster, dbo.view_Inventory_Details.Unit,
        //                         dbo.tbl_Disposal_Record.Condition_of_Item, dbo.tbl_Disposal_Record.Mode_of_Disposal, dbo.tbl_Disposal_Record.Reason_For_Transfer, dbo.tbl_Disposal_Record.Date_Transferred,
        //                         dbo.tbl_Disposal_Record.Appraised_Value, dbo.tbl_Disposal_Record.Accumulated_Depreciation, dbo.tbl_Disposal_Record.Accumulated_Impairment_Losses, dbo.view_EmployeeDivision.Full_Name AS [Approved by],
        //                         dbo.view_EmployeeDivision.Designation, dbo.view_SignatoriesDivision.Signatory_Name AS [Issued by], dbo.view_SignatoriesDivision.Signatory_Designation, dbo.view_SignatoriesDivision.Unit AS [OIC Unit],
        //                         dbo.tbl_Disposal_Record.Recipient, dbo.tbl_Disposal_Record.Received_By AS [Recipient Representative], dbo.tbl_Disposal_Record.Designation AS [Representative Designation], dbo.tbl_Disposal_Record.Inspector,
        //                         dbo.tbl_Disposal_Record.Chairman, dbo.tbl_Disposal_Record.Date_Witnessed, dbo.tbl_Disposal_Record.Document_No
        //FROM            dbo.tbl_Disposal_Record INNER JOIN
        //                         dbo.view_SignatoriesDivision ON dbo.tbl_Disposal_Record.fk_OIC_Id = dbo.view_SignatoriesDivision.pk_Signatory_Id INNER JOIN
        //                         dbo.view_EmployeeDivision ON dbo.tbl_Disposal_Record.fk_App_Id = dbo.view_EmployeeDivision.pk_Employee_Id LEFT OUTER JOIN
        //                         dbo.view_Inventory_Details ON dbo.tbl_Disposal_Record.fk_Inv_Id = dbo.view_Inventory_Details.pk_Id

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        //view_EmployeeDivision
        //        SELECT dbo.tbl_BOI_Employees.pk_Employee_Id, dbo.tbl_Divisions.pk_Division_Id, dbo.tbl_BOI_Employees.Full_Name, dbo.tbl_BOI_Employees.Designation, dbo.tbl_BOI_Employees.Employment_Status, dbo.tbl_Divisions.Unit
        //FROM            dbo.tbl_BOI_Employees INNER JOIN
        //                         dbo.tbl_Divisions ON dbo.tbl_BOI_Employees.fk_Division_Id = dbo.tbl_Divisions.pk_Division_Id

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        //view_EndUsersDivision
        //        SELECT dbo.tbl_BOI_End_Users.pk_EUser_Id, dbo.tbl_BOI_End_Users.User_Name, dbo.tbl_BOI_End_Users.User_Designation, dbo.tbl_BOI_End_Users.Employment_Status, dbo.tbl_Services.Service_Code,
        //                         dbo.tbl_Divisions.Division_Code, dbo.tbl_Divisions.Unit
        //FROM            dbo.tbl_Services INNER JOIN
        //                         dbo.tbl_Divisions ON dbo.tbl_Services.pk_Service_Id = dbo.tbl_Divisions.fk_Service_Id RIGHT OUTER JOIN
        //                         dbo.tbl_BOI_End_Users ON dbo.tbl_Divisions.pk_Division_Id = dbo.tbl_BOI_End_Users.fk_Division_Id

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        //view_Existing_Items_Details
        //        SELECT dbo.tbl_Inventory_Details.pk_Id, dbo.tbl_Inventory_Details.fk_Record_Id, dbo.tbl_Inventory_Details.fk_Article_Id, dbo.tbl_Inventory_Details.fk_Item_Code, dbo.tbl_Inventory_Details.fk_Supplier_Id,
        //                         dbo.tbl_Inventory_Details.fk_EUL_Id, dbo.tbl_Supplier.pk_Supplier_Id, dbo.tbl_Inventory_Details.fk_Accountable_Employee_Id, dbo.tbl_Inventory_Details.fk_End_User_Id, dbo.tbl_Category.Category_Name,
        //                         dbo.tbl_Subcategory.Subcategory_Name, dbo.tbl_Article.Article_Name, dbo.tbl_Items_Head.Description, dbo.tbl_Items_Head.UOM, dbo.tbl_Inventory_Details.Serial_No, dbo.tbl_Inventory_Details.Unit_Cost,
        //                         dbo.tbl_Supplier.Supplier_Name, dbo.tbl_Estimated_Useful_Life.EUL_Name, dbo.tbl_Inventory_Details.Date_Acquired, dbo.tbl_Inventory_Details.Warranty_Validity, dbo.tbl_Inventory_Details.Property_No,
        //                         dbo.tbl_Locations.Location_Name, dbo.tbl_Inventory_Details.Status, dbo.tbl_Inventory_Details.Remarks
        //FROM            dbo.tbl_Supplier RIGHT OUTER JOIN
        //                         dbo.tbl_Inventory_Details ON dbo.tbl_Supplier.pk_Supplier_Id = dbo.tbl_Inventory_Details.fk_Supplier_Id LEFT OUTER JOIN
        //                         dbo.tbl_Locations ON dbo.tbl_Inventory_Details.fk_Location_Id = dbo.tbl_Locations.pk_Location_Id LEFT OUTER JOIN
        //                         dbo.tbl_Category INNER JOIN
        //                         dbo.tbl_Subcategory ON dbo.tbl_Category.pk_Category_Id = dbo.tbl_Subcategory.fk_Category_Id INNER JOIN
        //                         dbo.tbl_Article ON dbo.tbl_Subcategory.pk_Subcategory_Id = dbo.tbl_Article.fk_Subcategory_Id ON dbo.tbl_Inventory_Details.fk_Article_Id = dbo.tbl_Article.pk_Article_Id LEFT OUTER JOIN
        //                         dbo.tbl_Items_Head ON dbo.tbl_Inventory_Details.fk_Item_Code = dbo.tbl_Items_Head.pk_Item_Code LEFT OUTER JOIN
        //                         dbo.tbl_Estimated_Useful_Life ON dbo.tbl_Inventory_Details.fk_EUL_Id = dbo.tbl_Estimated_Useful_Life.pk_EUL_Id

        //view_Generated_Property_No
        //        SELECT dbo.tbl_Inventory_Details.fk_Record_Id, dbo.tbl_Receiving_Items_Head.DR_No, dbo.tbl_Receiving_Items_Head.SI_No, dbo.tbl_Inventory_Details.Property_No, dbo.tbl_Items_Head.Description, dbo.tbl_Inventory_Details.Status,
        //                          dbo.tbl_Receiving_Items_Head.IAR_No
        //FROM            dbo.tbl_Inventory_Details LEFT OUTER JOIN
        //                         dbo.tbl_Items_Head ON dbo.tbl_Inventory_Details.fk_Item_Code = dbo.tbl_Items_Head.pk_Item_Code LEFT OUTER JOIN
        //                         dbo.tbl_Receiving_Items_Head ON dbo.tbl_Inventory_Details.fk_Record_Id = dbo.tbl_Receiving_Items_Head.pk_Record_Id

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        //view_Inventory_Details
        //        SELECT dbo.tbl_Inventory_Details.pk_Id, dbo.tbl_Inventory_Details.fk_Record_Id, dbo.tbl_Inventory_Details.fk_Article_Id, dbo.tbl_Inventory_Details.fk_Item_Code, dbo.tbl_Inventory_Details.fk_EUL_Id, dbo.tbl_Category.Category_Name,
        //                         dbo.tbl_Subcategory.Subcategory_Name, dbo.tbl_Article.Article_Name, dbo.tbl_Items_Head.Description, dbo.tbl_Items_Head.UOM, dbo.tbl_Inventory_Details.Serial_No, dbo.tbl_Inventory_Details.Unit_Cost,
        //                         dbo.tbl_Estimated_Useful_Life.EUL_Name, dbo.tbl_Inventory_Details.Date_Acquired, dbo.tbl_Inventory_Details.Warranty_Validity, dbo.tbl_Inventory_Details.Property_No, dbo.tbl_Locations.Location_Name,
        //                         dbo.tbl_Inventory_Details.Fund_Cluster, dbo.tbl_Inventory_Details.Status, dbo.tbl_Inventory_Details.Document_No, dbo.tbl_Inventory_Details.Date_Issued, dbo.tbl_Inventory_Details.Date_Received,
        //                         dbo.tbl_Inventory_Details.fk_Accountable_Employee_Id, dbo.view_EmployeeDivision.Full_Name AS [Accountable Officer], dbo.view_EmployeeDivision.Designation, dbo.view_EmployeeDivision.Unit,
        //                         dbo.tbl_Inventory_Details.fk_End_User_Id, dbo.view_EndUsersDivision.User_Name AS [End User], dbo.view_EndUsersDivision.User_Designation, dbo.view_EndUsersDivision.Service_Code,
        //                         dbo.view_EndUsersDivision.Division_Code, dbo.view_EndUsersDivision.Unit AS [End User Unit], dbo.tbl_Inventory_Details.fk_OIC, dbo.view_SignatoriesDivision.Signatory_Name AS OIC,
        //                         dbo.view_SignatoriesDivision.Signatory_Designation, dbo.view_SignatoriesDivision.Unit AS [OIC Unit], dbo.tbl_Inventory_Details.Inventory_Date, dbo.tbl_Inventory_Details.Remarks
        //FROM            dbo.tbl_Items_Head RIGHT OUTER JOIN
        //                         dbo.view_SignatoriesDivision RIGHT OUTER JOIN
        //                         dbo.tbl_Locations RIGHT OUTER JOIN
        //                         dbo.tbl_Inventory_Details ON dbo.tbl_Locations.pk_Location_Id = dbo.tbl_Inventory_Details.fk_Location_Id LEFT OUTER JOIN
        //                         dbo.view_EndUsersDivision ON dbo.tbl_Inventory_Details.fk_End_User_Id = dbo.view_EndUsersDivision.pk_EUser_Id ON dbo.view_SignatoriesDivision.pk_Signatory_Id = dbo.tbl_Inventory_Details.fk_OIC LEFT OUTER JOIN
        //                         dbo.view_EmployeeDivision ON dbo.tbl_Inventory_Details.fk_Accountable_Employee_Id = dbo.view_EmployeeDivision.pk_Employee_Id LEFT OUTER JOIN
        //                         dbo.tbl_Category INNER JOIN
        //                         dbo.tbl_Subcategory ON dbo.tbl_Category.pk_Category_Id = dbo.tbl_Subcategory.fk_Category_Id INNER JOIN
        //                         dbo.tbl_Article ON dbo.tbl_Subcategory.pk_Subcategory_Id = dbo.tbl_Article.fk_Subcategory_Id ON dbo.tbl_Inventory_Details.fk_Article_Id = dbo.tbl_Article.pk_Article_Id ON
        //                         dbo.tbl_Items_Head.pk_Item_Code = dbo.tbl_Inventory_Details.fk_Item_Code LEFT OUTER JOIN
        //                         dbo.tbl_Estimated_Useful_Life ON dbo.tbl_Inventory_Details.fk_EUL_Id = dbo.tbl_Estimated_Useful_Life.pk_EUL_Id
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        //view_ItemHistory
        //        SELECT dbo.view_Inventory_Details.fk_Article_Id, dbo.tbl_Item_History.fk_Inv_Id, dbo.view_Inventory_Details.Category_Name, dbo.view_Inventory_Details.Subcategory_Name, dbo.view_Inventory_Details.Article_Name,
        //                         dbo.view_Inventory_Details.Description, dbo.view_Inventory_Details.Property_No, dbo.view_Inventory_Details.Unit_Cost, dbo.tbl_Item_History.Date, dbo.tbl_Item_History.Document_No,
        //                         dbo.view_EmployeeDivision.Full_Name, dbo.view_EmployeeDivision.Unit, dbo.tbl_Item_History.Status, dbo.tbl_Item_History.Remarks, dbo.view_Inventory_Details.Fund_Cluster
        //FROM            dbo.tbl_Item_History INNER JOIN
        //                         dbo.view_EmployeeDivision ON dbo.tbl_Item_History.fk_End_User_Id = dbo.view_EmployeeDivision.pk_Employee_Id INNER JOIN
        //                         dbo.view_Inventory_Details ON dbo.tbl_Item_History.fk_Inv_Id = dbo.view_Inventory_Details.pk_Id

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        //view_PullOutRecords
        //        SELECT dbo.tbl_Pull_Out_Record.fk_Inv_Id, dbo.view_Inventory_Details.fk_End_User_Id, dbo.view_Inventory_Details.fk_OIC, dbo.view_Inventory_Details.Description, dbo.view_Inventory_Details.UOM,
        //                         dbo.view_Inventory_Details.Serial_No, dbo.view_Inventory_Details.Property_No, dbo.view_Inventory_Details.Status, dbo.tbl_Pull_Out_Record.Remarks, dbo.tbl_Pull_Out_Record.ReceivedBy,
        //                         dbo.tbl_Pull_Out_Record.Date_Pull_Out, dbo.tbl_Pull_Out_Record.Pull_Out_From, dbo.tbl_Pull_Out_Record.End_User_Unit, dbo.view_SignatoriesDivision.Signatory_Name, dbo.view_SignatoriesDivision.Unit,
        //                         dbo.tbl_Pull_Out_Record.Date_Received, dbo.tbl_Pull_Out_Record.NotedBy, dbo.tbl_Pull_Out_Record.RRP_No
        //FROM            dbo.view_SignatoriesDivision RIGHT OUTER JOIN
        //                         dbo.tbl_Pull_Out_Record ON dbo.view_SignatoriesDivision.pk_Signatory_Id = dbo.tbl_Pull_Out_Record.fk_OIC LEFT OUTER JOIN
        //                         dbo.view_Inventory_Details ON dbo.tbl_Pull_Out_Record.fk_Inv_Id = dbo.view_Inventory_Details.pk_Id

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        //view_Received_Items
        //        SELECT dbo.view_Inventory_Details.pk_Id, dbo.tbl_Receiving_Items_Head.pk_Record_Id, dbo.tbl_Receiving_Items_Head.DR_No, dbo.tbl_Receiving_Items_Head.SI_No, dbo.tbl_Receiving_Items_Head.APR_No,
        //                         dbo.tbl_Supplier.Supplier_Name, dbo.view_Inventory_Details.Category_Name, dbo.view_Inventory_Details.Subcategory_Name, dbo.view_Inventory_Details.Article_Name, dbo.view_Inventory_Details.Description,
        //                         dbo.view_Inventory_Details.UOM, dbo.view_Inventory_Details.Serial_No, dbo.view_Inventory_Details.Unit_Cost, dbo.view_Inventory_Details.EUL_Name, dbo.view_Inventory_Details.Date_Acquired,
        //                         dbo.view_Inventory_Details.Warranty_Validity, dbo.view_Inventory_Details.Location_Name, dbo.view_Inventory_Details.Property_No, dbo.view_Inventory_Details.Status, dbo.view_Inventory_Details.Remarks,
        //                         dbo.view_Inventory_Details.[Accountable Officer] AS Accountable_Officer, dbo.view_Inventory_Details.[End User] AS End_User, dbo.tbl_Receiving_Items_Head.IAR_No
        //FROM            dbo.view_Inventory_Details INNER JOIN
        //                         dbo.tbl_Receiving_Items_Head ON dbo.view_Inventory_Details.fk_Record_Id = dbo.tbl_Receiving_Items_Head.pk_Record_Id INNER JOIN
        //                         dbo.tbl_Supplier ON dbo.tbl_Receiving_Items_Head.fk_Supplier_Id = dbo.tbl_Supplier.pk_Supplier_Id

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        //view_Receiving_History
        //        SELECT dbo.tbl_Items_Head.Description, dbo.tbl_Receving_Items_Details.Quantity, dbo.tbl_Receving_Items_Details.Unit_Cost, dbo.tbl_Receving_Items_Details.Total_Cost, dbo.tbl_Supplier.Supplier_Name,
        //                         dbo.tbl_Receiving_Items_Head.DR_No, dbo.tbl_Receiving_Items_Head.SI_No, dbo.tbl_Receiving_Items_Head.IAR_No, dbo.tbl_Receiving_Items_Head.Received_Date
        //FROM            dbo.tbl_Items_Head RIGHT OUTER JOIN
        //                         dbo.tbl_Receving_Items_Details ON dbo.tbl_Items_Head.pk_Item_Code = dbo.tbl_Receving_Items_Details.fk_Item_Code LEFT OUTER JOIN
        //                         dbo.tbl_Receiving_Items_Head INNER JOIN
        //                         dbo.tbl_Supplier ON dbo.tbl_Receiving_Items_Head.fk_Supplier_Id = dbo.tbl_Supplier.pk_Supplier_Id ON dbo.tbl_Receving_Items_Details.fk_Record_Id = dbo.tbl_Receiving_Items_Head.pk_Record_Id

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        //view_Receiving_Report
        //        SELECT dbo.tbl_Supplier.Supplier_Name, dbo.tbl_Receiving_Items_Head.DR_No, dbo.tbl_Receiving_Items_Head.SI_No, dbo.tbl_Receiving_Items_Head.APR_No, dbo.tbl_Receiving_Items_Head.Requisitioning_Office,
        //                         dbo.tbl_Receiving_Items_Head.Responsibility_Code, dbo.tbl_Receiving_Items_Head.IAR_No, dbo.tbl_Receiving_Items_Head.Received_By, dbo.tbl_Receiving_Items_Head.Received_Date,
        //                         dbo.tbl_Receiving_Items_Head.Inspected_By, dbo.tbl_Receiving_Items_Head.Inspected_Date, dbo.tbl_Receiving_Items_Head.Accepted_By, dbo.tbl_Receiving_Items_Head.Fund_Cluster,
        //                         dbo.tbl_Receiving_Items_Head.Remarks AS [Item Head Remarks], dbo.tbl_Receiving_Items_Head.pk_Record_Id, dbo.tbl_Receving_Items_Details.fk_Article_Id, dbo.tbl_Receving_Items_Details.fk_Item_Code,
        //                         dbo.tbl_Receiving_Items_Head.fk_Supplier_Id, dbo.tbl_Receving_Items_Details.fk_EUL_Id, dbo.tbl_Receving_Items_Details.PR_No, dbo.tbl_Category.Category_Name, dbo.tbl_Subcategory.Subcategory_Name,
        //                         dbo.tbl_Article.Article_Name, dbo.tbl_Items_Head.Description, dbo.tbl_Items_Head.UOM, dbo.tbl_Receving_Items_Details.Serial_No, dbo.tbl_Receving_Items_Details.Quantity, dbo.tbl_Receving_Items_Details.Unit_Cost,
        //                         dbo.tbl_Receving_Items_Details.Total_Cost, dbo.tbl_Estimated_Useful_Life.EUL_Name, dbo.tbl_Receving_Items_Details.Date_Acquired, dbo.tbl_Receving_Items_Details.Warranty_Validity,
        //                         dbo.tbl_Receving_Items_Details.Remarks
        //FROM            dbo.tbl_Items_Head INNER JOIN
        //                         dbo.tbl_Receving_Items_Details ON dbo.tbl_Items_Head.pk_Item_Code = dbo.tbl_Receving_Items_Details.fk_Item_Code INNER JOIN
        //                         dbo.tbl_Receiving_Items_Head ON dbo.tbl_Receving_Items_Details.fk_Record_Id = dbo.tbl_Receiving_Items_Head.pk_Record_Id INNER JOIN
        //                         dbo.tbl_Supplier ON dbo.tbl_Receiving_Items_Head.fk_Supplier_Id = dbo.tbl_Supplier.pk_Supplier_Id INNER JOIN
        //                         dbo.tbl_Estimated_Useful_Life ON dbo.tbl_Receving_Items_Details.fk_EUL_Id = dbo.tbl_Estimated_Useful_Life.pk_EUL_Id INNER JOIN
        //                         dbo.tbl_Article ON dbo.tbl_Receving_Items_Details.fk_Article_Id = dbo.tbl_Article.pk_Article_Id INNER JOIN
        //                         dbo.tbl_Subcategory ON dbo.tbl_Article.fk_Subcategory_Id = dbo.tbl_Subcategory.pk_Subcategory_Id INNER JOIN
        //                         dbo.tbl_Category ON dbo.tbl_Subcategory.fk_Category_Id = dbo.tbl_Category.pk_Category_Id

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        //view_RepairRecords
        //        SELECT dbo.view_Inventory_Details.Description, dbo.view_Inventory_Details.Serial_No, dbo.view_Inventory_Details.Property_No, dbo.tbl_Repair_Record.Date_Repaired, dbo.tbl_Repair_Record.Status_Of_Item,
        //                         dbo.tbl_Repair_Record.Reference_No, dbo.tbl_Repair_Record.Remarks, dbo.view_Inventory_Details.[End User], dbo.view_Inventory_Details.[End User Unit]
        //FROM            dbo.view_Inventory_Details RIGHT OUTER JOIN
        //                         dbo.tbl_Repair_Record ON dbo.view_Inventory_Details.pk_Id = dbo.tbl_Repair_Record.fk_Inv_Id

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        //view_ServicesDivision
        //        SELECT dbo.tbl_Divisions.pk_Division_Id, dbo.tbl_Services.pk_Service_Id, dbo.tbl_Services.Service_Code, dbo.tbl_Divisions.Division_Name, dbo.tbl_Divisions.Division_Code, dbo.tbl_Divisions.Unit
        //FROM            dbo.tbl_Divisions LEFT OUTER JOIN
        //                         dbo.tbl_Services ON dbo.tbl_Divisions.fk_Service_Id = dbo.tbl_Services.pk_Service_Id

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        //view_SignatoriesDivision
        //        SELECT dbo.tbl_BOI_Signatories.pk_Signatory_Id, dbo.tbl_BOI_Signatories.Signatory_Name, dbo.tbl_BOI_Signatories.Signatory_Designation, dbo.tbl_BOI_Signatories.Employment_Status, dbo.tbl_Divisions.Unit
        //FROM            dbo.tbl_BOI_Signatories LEFT OUTER JOIN
        //                         dbo.tbl_Divisions ON dbo.tbl_BOI_Signatories.fk_Division_Id = dbo.tbl_Divisions.pk_Division_Id

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
    }
}
