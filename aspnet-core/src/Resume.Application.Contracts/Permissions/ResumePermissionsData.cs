using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Resume.Permissions
{
    public static class ResumePermissionsData
    {
        public static List<CustomPermission> GetAll(string GroupName)
        {
            var Result = new List<CustomPermission>();

            var RootGroupName = GroupName;

            Type t = typeof(ResumePermissions);
            var NestedTypes = t.GetNestedTypes(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (var NestedType in NestedTypes)
            {
                var NestedTypeName = NestedType.Name;
                var Fields = NestedType.GetFields(BindingFlags.Static | BindingFlags.Public);

                //取得Field.Name名稱是 Default的 做為 GroupName 而沒有Default欄位 則直接跳過
                var itemField = Fields.FirstOrDefault(p => p.Name == "Default");
                if (itemField == null)
                    continue;
                GroupName = itemField.GetValue(null).ToString();

                foreach (var Field in Fields)
                {
                    var item = new CustomPermission();
                    item.key = Field.GetValue(null).ToString();
                    item.value = "Permission:" + (Field.Name == "Default" ? NestedTypeName : Field.Name);
                    item.parent = Field.Name == "Default" ? RootGroupName : GroupName;
                    Result.Add(item);
                }
            }

            return Result;
        }
    }
}
