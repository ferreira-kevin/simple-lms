using lms;
using lms.Data;
using lms.Data.Repositories;
using lms.Providers;
using lms.UseCases.Common;
using lms.UseCases.Manager.AcademicRecord;
using lms.UseCases.Student;
using lms.UseCases.Student.Assignment;
using lms.UseCases.Student.Assignments;
using lms.UseCases.Student.Grades;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddDbContext<LmsDbContext>(options =>
    options.UseInMemoryDatabase("LmsInMemoryDb"));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IAssignmentRepository, AssignmentRepository>();
builder.Services.AddScoped<IAssignmentAttemptRepository, AssignmentAttemptRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IQuestionAnswerRepository, QuestionAnswerRepository>();
builder.Services.AddScoped<IGradeRepository, GradeRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IFinalizeAssignment, FinalizeAssignment>();
builder.Services.AddScoped<INextQuestion, NextQuestion>();
builder.Services.AddScoped<IPreviousQuestion, PreviousQuestion>();
builder.Services.AddScoped<ISelectOption, SelectOption>();
builder.Services.AddScoped<IStartAssignment, StartAssignment>();
builder.Services.AddScoped<IUploadFile, UploadFile>();
builder.Services.AddScoped<IListAssignments, ListAssignments>();
builder.Services.AddScoped<IListGrades, ListGrades>();
builder.Services.AddScoped<ICreateStudent, CreateStudent>();
builder.Services.AddScoped<IListStudents, ListStudents>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddScoped<ILogin, Login>();

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();

builder.Services.AddSingleton<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddSingleton<CustomAuthenticationService>();

//builder.Services.AddMudServices();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

await app.RunAsync();
