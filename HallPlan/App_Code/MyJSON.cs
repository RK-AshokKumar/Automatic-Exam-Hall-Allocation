using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Web.Script.Serialization;

/// <summary>
/// Summary description for MyJSON
/// </summary>
public class MyJSON
{
	public MyJSON()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string DataTableToJSON(DataTable table, String tablename)
    {
        JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
        List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
        Dictionary<string, object> childRow;
        foreach (DataRow row in table.Rows)
        {
            childRow = new Dictionary<string, object>();
            foreach (DataColumn col in table.Columns)
            {
                childRow.Add(col.ColumnName, row[col]);
            }
            parentRow.Add(childRow);
        }
        String jsonobj = "{\"" + tablename + "\":" + jsSerializer.Serialize(parentRow) + "}";
        return jsonobj;
    }  
}
