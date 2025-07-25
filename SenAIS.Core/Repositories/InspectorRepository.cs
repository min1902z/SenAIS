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
                table.Columns.Add("InspectorID", typeof(int));
                table.Columns.Add("InspectorName", typeof(string));

                foreach (var inspector in inspectors)
                {
                    var row = table.NewRow();
                    row["InspectorID"] = inspector.InspectorID;
                    row["InspectorName"] = inspector.InspectorName;
                    table.Rows.Add(row);
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
                    if (row.RowState == DataRowState.Deleted)
                        continue;

                    var name = row["InspectorName"]?.ToString()?.Trim();

                    // Nếu không có tên thì bỏ qua
                    if (string.IsNullOrWhiteSpace(name))
                        continue;

                    bool hasId = int.TryParse(row["InspectorID"]?.ToString(), out int id);

                    if (hasId && id > 0)
                    {
                        // Cập nhật nếu đã tồn tại trong DB
                        var existing = db.Inspectors.FirstOrDefault(i => i.InspectorID == id);
                        if (existing != null)
                        {
                            existing.InspectorName = name;
                        }
                        else
                        {
                            // Nếu ID tồn tại nhưng không có trong DB => tránh thêm lại
                            continue;
                        }
                    }
                    else
                    {
                        // Chỉ thêm mới nếu chưa tồn tại tên
                        bool exists = db.Inspectors.Any(x => x.InspectorName == name);
                        if (!exists)
                        {
                            db.Inspectors.Add(new Inspector
                            {
                                InspectorName = name
                            });
                        }
                    }
                }

                db.SaveChanges();
            }
        }
        public void DeleteInspector(int inspectorId)
        {
            using (var db = new SenAISDB_HDEntities())
            {
                var inspector = db.Inspectors.FirstOrDefault(i => i.InspectorID == inspectorId);
                if (inspector != null)
                {
                    db.Inspectors.Remove(inspector);
                    db.SaveChanges();
                }
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
