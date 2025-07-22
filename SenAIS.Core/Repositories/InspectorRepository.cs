using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenAIS.Core.Repositories
{
    public class InspectorRepository
    {
        public DataTable GetInspectorData()
        {
            using (var db = new SenAISDB_HDEntities())
            {
                var inspectors = db.Inspectors.ToList();
                var table = new DataTable();
                table.Columns.Add("Id", typeof(int));
                table.Columns.Add("InspectorName", typeof(string));

                foreach (var inspector in inspectors)
                {
                    table.Rows.Add(inspector.InspectorID, inspector.InspectorName);
                }

                return table;
            }
        }

        public void UpdateInspectorData(DataTable dataTable)
        {
            using (var db = new SenAISDB_HDEntities())
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    int id = (int)row["Id"];
                    string name = row["InspectorName"].ToString();

                    var inspector = db.Inspectors.FirstOrDefault(i => i.InspectorID == id);
                    if (inspector != null)
                    {
                        inspector.InspectorName = name;
                    }
                    else
                    {
                        db.Inspectors.Add(new Inspector
                        {
                            InspectorID = id,
                            InspectorName = name
                        });
                    }
                }
                db.SaveChanges();
            }
        }

        public DataTable GetInspectorList()
        {
            using (var db = new SenAISDB_HDEntities())
            {
                var names = db.Inspectors.Select(i => i.InspectorName).ToList();
                var table = new DataTable();
                table.Columns.Add("InspectorName", typeof(string));
                foreach (var name in names)
                {
                    table.Rows.Add(name);
                }
                return table;
            }
        }
    }
}
