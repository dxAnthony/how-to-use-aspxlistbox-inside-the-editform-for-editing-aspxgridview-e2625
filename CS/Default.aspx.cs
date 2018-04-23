using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {

    }

    protected void ASPxListBox1_DataBound(object sender, EventArgs e) {
        var listBox = (ASPxListBox)sender;

        int editingRowVisibleIndex = ASPxGridView1.EditingRowVisibleIndex;
        string rowValue = ASPxGridView1.GetRowValues(editingRowVisibleIndex, "Description").ToString();
        string[] rowValueItems = rowValue.Split(';');

        List<string> rowValueItemsAsList = new List<string>();
        rowValueItemsAsList.AddRange(rowValueItems);

        foreach (ListEditItem item in listBox.Items) {
            if (rowValueItemsAsList.Contains(item.Value.ToString())) {
                item.Selected = true;
            }
        }
    }
    protected void ASPxGridView1_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e) {
        var grid = (ASPxGridView)sender;
        ASPxListBox listBox = (ASPxListBox)grid.FindEditFormTemplateControl("ASPxListBox1");

        string selectedItemsAsString = string.Empty;

        foreach (ListEditItem item in listBox.SelectedItems) {
            selectedItemsAsString += item.Text + ";";
        }

        if (selectedItemsAsString.Length > 0) {
            selectedItemsAsString = selectedItemsAsString.Trim(';');
        }

        // e.NewValues["Description"] = selectedItemsAsString; //Uncomment this line to allow editing 
    }



    protected void ASPxGridView1_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e) {
        e.RowError = "Data source modification is not allowed. To test the updating operation, download the project and run it locally";//Remove this line in local environment
    }
}