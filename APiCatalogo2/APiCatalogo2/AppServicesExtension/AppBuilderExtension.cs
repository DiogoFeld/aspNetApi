namespace APiCatalogo2.AppServicesExtension
{
    public static class AppBuilderExtension
    {
        public static IApplicationBuilder UseExeptionHandling(this IApplicationBuilder app, IWebHostEnvironment enviroment)
        {
            // Configure the HTTP request pipeline.
            if (enviroment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            return app;
        }


        public static IApplicationBuilder UseAPPCors(this IApplicationBuilder app)
        {
            app.UseCors(p =>
            {
                p.AllowAnyOrigin();
                p.WithMethods("GET");
                p.AllowAnyHeader();
            });
            return app;
        }

        public static IApplicationBuilder UseSwaggerMiddleware(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            return app;
        }






    }
}
