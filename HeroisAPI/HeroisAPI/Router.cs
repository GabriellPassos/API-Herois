using HeroisAPI.Models;
using HeroisAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HeroisAPI
{
    static public class Router
    {
        public static void Map(WebApplication app)
        {
            app.MapPost("heroi/cadastrar", ([FromBody] Heroi heroi, HeroiService heroiService) =>
            {
                try
                {
                    Resultado resultado = heroiService.Cadastrar(heroi).Result;
                    if (resultado.Mensagem != null)
                    {
                        return Results.Ok(resultado.Mensagem);
                    }
                    return Results.Ok(resultado.Dados);
                }
                catch (Exception e)
                {
                    return Results.Ok();
                }
            });
            app.MapGet("heroi", ([FromQuery] int id, HeroiService heroiService) =>
            {
                try
                {
                    Resultado resultado = heroiService.buscarPorId(id);
                    if (resultado.Mensagem != null)
                    {
                        return Results.Ok(resultado.Mensagem);
                    }
                    return Results.Ok(resultado.Dados);

                }
                catch (Exception e)
                {
                    return Results.Ok();
                }
            });
            app.MapGet("heroi/todos", (HeroiService heroiService) =>
            {
                try
                {
                    Resultado resultado = heroiService.buscarTodos();
                    if (resultado.Mensagem != null)
                    {
                        return Results.Ok(resultado.Mensagem);
                    }
                    return Results.Ok(resultado.Dados);
                }
                catch (Exception e)
                {
                    return Results.Ok();
                }
            });
            app.MapPut("heroi/editar", ([FromBody] Heroi heroi, HeroiService heroiService) =>
            {
                try
                {
                    Resultado resultado = heroiService.Editar(heroi).Result;
                    if (resultado.Mensagem != null)
                    {
                        return Results.Ok(resultado.Mensagem);
                    }
                    return Results.Ok(resultado.Dados);
                }
                catch (Exception e)
                {
                    return Results.Ok();
                }
            });
            app.MapDelete("heroi/remover", ([FromQuery] int id, HeroiService heroiService) =>
            {
                try
                {
                    Resultado resultado = heroiService.Remover(id);
                    return Results.Ok(resultado);
                }
                catch (Exception e)
                {
                    return Results.Ok();
                }
            });

            /* ROTAS SUPER PODER*/

            app.MapPost("superpoder/cadastrar", ([FromBody] SuperPoder superPoder, SuperPoderService superPoderService) =>
            {
                try
                {
                    Resultado resultado = superPoderService.Cadastrar(superPoder).Result;
                    if (resultado.Mensagem != null)
                    {
                        return Results.Ok(resultado.Mensagem);
                    }
                    return Results.Ok(resultado.Dados);
                }
                catch (Exception e)
                {
                    return Results.Ok();
                }
            });
            app.MapGet("superpoder/todos", (SuperPoderService superPoderService) =>
            {
                try
                {
                    Resultado resultado = superPoderService.buscarTodos();
                    if (resultado.Mensagem != null)
                    {
                        return Results.Ok(resultado.Mensagem);
                    }
                    return Results.Ok(resultado.Dados);
                }
                catch (Exception e)
                {
                    
                    return Results.Ok();
                }
            });
            app.MapPut("superpoder/editar", ([FromBody] SuperPoder superPoder, SuperPoderService superPoderService) =>
            {
                try
                {
                    Resultado resultado = superPoderService.Editar(superPoder).Result;
                    if (resultado.Mensagem != null)
                    {
                        return Results.Ok(resultado.Mensagem);
                    }
                    return Results.Ok(resultado.Dados);
                }
                catch (Exception e)
                {
                    return Results.Ok();
                }
            });
            app.MapDelete("superpoder/remover", ([FromQuery] int id, SuperPoderService superPoderService) =>
            {
                try
                {
                    Resultado resultado = superPoderService.Remover(id);
                    if (resultado.Mensagem != null)
                    {
                        return Results.Ok(resultado.Mensagem);
                    }
                    return Results.Ok(resultado.Dados);
                }
                catch (Exception e)
                {
                    return Results.Ok();
                }
            });
        }
    }
}
