using Wba.Oefening.Students.Web.ViewComponents;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

//for use with viewcomponent RandomUserViewComponent
builder.Services.AddTransient<RandomUserViewComponent>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
     name: "Courses",
     pattern: "Courses",
     defaults: new { Controller = "Courses", Action = "ShowCourses" });

app.MapControllerRoute(
     name: "Courses",
     pattern: "Courses/{id}/students",
     defaults: new { Controller = "Courses", Action = "ShowCourseDetail" });

app.MapControllerRoute(
     name: "Students",
     pattern: "Students",
     defaults: new { Controller = "Students", Action = "ShowStudents" });

app.MapControllerRoute(
                     name: "StudentDetail",
                     pattern: "Students/{id:int}",
                     defaults: new { Controller = "Students", Action = "ShowStudentDetail" });

app.MapControllerRoute(
     name: "Teachers",
     pattern: "Teachers",
     defaults: new { Controller = "Teachers", Action = "ShowTeachers" });

app.MapControllerRoute(
                     name: "TeacherDetail",
                     pattern: "Teachers/{teacherId:long}",
                     defaults: new { Controller = "Teachers", Action = "ShowTeacherDetail" });


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
