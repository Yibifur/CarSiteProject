using UdemyCarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.BrandHandler;
using UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.CategoryHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using UdemyCarBook.Application.Features.Mediator.Handlers.AuthorHandlers;
using UdemyCarBook.Application.Features.Mediator.Handlers.BlogHandlers;
using UdemyCarBook.Application.Features.Mediator.Handlers.CarPricingHandlers;
using UdemyCarBook.Application.Features.Mediator.Handlers.TagCloudHandlers;
using UdemyCarBook.Application.Features.Mediator.Handlers.TesimonialHandlers;
using UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.BlogInterfaces;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Application.Interfaces.CarPricingInterfaces;
using UdemyCarBook.Application.Services;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;
using UdemyCarBook.Persistence.Repositories;
using UdemyCarBook.Persistence.Repositories.BlogRepositories;
using UdemyCarBook.Persistence.Repositories.CarPricingRepository;
using UdemyCarBook.Persistence.Repositories.CarRepositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<CarBookContext>();
builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddScoped<ICarRepository,CarRepository>();
builder.Services.AddScoped<IBlogRepository,BlogRepository>();
builder.Services.AddScoped<ICarPricingRepository,CarPricingRepository>();
//About
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();
//Banner 
builder.Services.AddScoped<GetBannerByIdQueryHandler>();
builder.Services.AddScoped<GetBannerQueryHandler>();
builder.Services.AddScoped<RemoveBannerCommandHandler>();
builder.Services.AddScoped<CreateBannerCommandHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();
//Brand
builder.Services.AddScoped<GetBrandByIdQueryHandler>();
builder.Services.AddScoped<GetBrandQueryHandler>();
builder.Services.AddScoped<RemoveBrandCommandHandler>();
builder.Services.AddScoped<CreateBrandCommandHandler>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();
//Car
builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<GetCarQueryHandler>();
builder.Services.AddScoped<RemoveCarCommandHandler>();
builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<GetCarWithBrandQueryHandler>();
builder.Services.AddScoped<GetLast5CarQueryHandler>();
//Category
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();
//Contact
builder.Services.AddScoped<GetContactByIdQueryHandler>();
builder.Services.AddScoped<GetContactQueryHandler>();
builder.Services.AddScoped<RemoveContactCommandHandler>();
builder.Services.AddScoped<CreateContactCommandHandler>();
builder.Services.AddScoped<UpdateContactCommandHandler>();
//Testimonial
builder.Services.AddScoped<GetTestimonialByIdQueryHandler>();
builder.Services.AddScoped<GetTestimonialQueryHandler>();
builder.Services.AddScoped<RemoveTestimonialCommandHandler>();
builder.Services.AddScoped<CreateTestimonialCommandHandler>();
builder.Services.AddScoped<UpdateTestimonialCommandHandler>();
//Blog
builder.Services.AddScoped<GetBlogByIdQueryHandler>();
builder.Services.AddScoped<GetBlogQueryHandler>();
builder.Services.AddScoped<GetLast3BlogsWithAuthorQueryHandler>();
builder.Services.AddScoped<RemoveBlogCommandHandler>();
builder.Services.AddScoped<CreateBlogCommandHandler>();
builder.Services.AddScoped<UpdateBlogCommandHandler>();
builder.Services.AddScoped<GetAllBlogsWithAuthorQueryHandler>();
//Author
builder.Services.AddScoped<GetAuthorByIdQueryHandler>();
builder.Services.AddScoped<GetAuthorQueryHandler>();
builder.Services.AddScoped<RemoveAuthorCommandHandler>();
builder.Services.AddScoped<CreateAuthorCommandHandler>();
builder.Services.AddScoped<UpdateAuthorCommandHandler>();
//CarPricing
builder.Services.AddScoped<GetCarPricingWithCarsQueryHandler>();
//TagCloud
builder.Services.AddScoped<GetTagCloudByIdQueryHandler>();
builder.Services.AddScoped<GetTagCloudsQueryHandler>();
builder.Services.AddScoped<RemoveTagCloudCommandHandler>();
builder.Services.AddScoped<CreateTagCloudCommandHandler>();
builder.Services.AddScoped<UpdateTagCloudCommandHandler>();

// Add services to the container.
builder.Services.AddApplicationServices(builder.Configuration);
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

app.MapControllers();

app.Run();
