using Application.Authors;
using Application.Books;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();

            services.AddScoped<IAuthorService, AuthorService>();

            return services;
        }
    }
}
