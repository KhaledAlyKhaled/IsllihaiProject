namespace IsllihaiProjectDAL.Entities.Enums
{
    // أسماء الأدوار في مكان واحد، وتستخدمها في كل حتة:
    //   - الـ Seed:      الأدوار اللي في الداتابيز لازم تطابقها حرف بحرف
    //   - الـ Register:  AddToRoleAsync(user, RoleNames.Customer)
    //   - الـ Authorize: [Authorize(Roles = RoleNames.Technician)]
    // كده التهجئة الغلط (زي "Technicain") مش هتتكرر لأنك مش بتكتب النص بإيدك.
    public static class RoleNames
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";
        public const string Technician = "Technician";
    }
}
