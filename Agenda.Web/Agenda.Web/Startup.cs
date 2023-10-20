public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    app.UseDefaultFiles(); // Adicione esta linha ANTES de UseStaticFiles
    app.UseStaticFiles();
}
