using DataAccess.Models;
using DataAccess.Wrapper;
using BusinessLogic.Services;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces.Service;
using Domain.Interfaces.Wrapper;

namespace BackendApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<VitalityMasteryContext>(
                options => options.UseSqlServer(builder.Configuration["ConnectionStrings"]));



            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ITrainerService, TrainerService>();
            builder.Services.AddScoped<ITrainingService, TrainingService>();
            builder.Services.AddScoped<IScheduleService, ScheduleService>();
            builder.Services.AddScoped<IRolesService, RolesService>();
            builder.Services.AddScoped<IPublicationService, PublicationService>();
            builder.Services.AddScoped<IProductsService, ProductsService>();
            builder.Services.AddScoped<IPhotoUsersService, PhotoUsersService>();
            builder.Services.AddScoped<INutritionService, NutritionService>();
            builder.Services.AddScoped<IMessageUsersService, MessageUsersService>();
            builder.Services.AddScoped<IGroupsService, GroupsService>();
            builder.Services.AddScoped<IGroupMembersService, GroupMembersService>();
            builder.Services.AddScoped<IFriendService, FriendService>();
            builder.Services.AddScoped<IDialogsService, DialogsService>();
            builder.Services.AddScoped<ICommentsService, CommentsService>();
            builder.Services.AddScoped<IAchievementsService, AchievementsService>();
            builder.Services.AddScoped<IUserToRuleService, UserToRuleService>();
            builder.Services.AddScoped<IUserToDialogsService, UserToDialogsService>();
            builder.Services.AddScoped<IUserToAchievementService, UserToAchievementsService>();
            builder.Services.AddScoped<IUserTrainingService, UserTrainingService>();
            builder.Services.AddScoped<IUserNutritionService, UserNutritionService>();
            builder.Services.AddScoped<ITrainersScheduleService, TrainersScheduleService>();

            builder.Services.AddCors(o => o.AddPolicy("MyPolicy",builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyMethod();
            }));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("MyPolicy");

            app.MapControllers();

            app.Run();
        }
    }
}
