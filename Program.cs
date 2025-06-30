builder.Services.AddDefaultIdentity<ApplicationUser>(options => { /* options */ })
    .AddRoles<IdentityRole>() // <-- This line is required for RoleManager
    .AddEntityFrameworkStores<ApplicationDbContext>();