using Database.Collections;
using Domain.Authors;
using Domain.Books;
using Microsoft.Extensions.DependencyInjection;

namespace Database.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDatabaseLayer(this IServiceCollection services)
        {
            services.AddScoped<IBookCollection, BookCollection>();

            services.AddScoped<IAuthorCollection, AuthorCollection>();

            return services;
        }
    }
}
