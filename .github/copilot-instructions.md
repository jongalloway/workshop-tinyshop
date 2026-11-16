## Backend
- The Products project is the backend API.
- It is built with .NET Minimal APIs.
- It uses Entity Framework Core with an in-memory database.
- Follow OpenAPI best practices.

## Frontend
- The Store project is a .NET 10 Blazor Server application.
- It uses default Bootstrap styling.
- The UI should have a modern look and feel.
- Put CSS in `.razor.css` files.

## Misc
- To display an image, always use `ImagePrefix` in the web front end. It comes from `Configuration["ImagePrefix"]`; inject `IConfiguration Configuration`.
- Ignore all `*.md` files in the **lab** folder when making code suggestions.

## Commit Messages
- When creating Commit messages, summarize in a few sentences and then highlight the top 5 changes with emoji and short descriptions