# APIREST Herois
## Sobre o projeto
  Esta api foi montade utilizando minimal api, a ideia foi de trazer velocidade para o projeto além de menor poluição visual. Optei por utilizar uma classe Router para fazer o gerencimaneto das rotas para evitar código sobresalente dado a dimensão do projeto. Além disso decidi utilizar um framework FluentValidation para gerar as validações e foi de grande ajuda. A ideia geral foi economizar de tempo e ser o mais objetivo possível.

## :mag_right: Visão geral
## Rotas
### Herois
  Controle de cadastro.
| Método     | Rota               | Descrição|
| :---       |:---                |:---|
| `POST`     | /registro          |  Registra um novo herói           .|
| `GET`      | /heroi/:id         |  Busca um herói por Id            .|
| `GET`      | /heroi/todos       |  Busca todos os heróis cadastrados.|
| `PUT`      | /heroi/editar      |  Edita um registro                .|
| `DELETE`   | /heroi/remover/:id |  Remove cadastro por Id           .|
#### Exemplo:
```Json
{
  "id": 0,
  "nome": "string",
  "nomeHeroi": "string",
  "altura": 0,
  "peso": 0,
  "nascimento": "2023-11-09",
  "superPoderes": [
    {
      "id": 0,
      "nome": "string",
      "descricao": "string"
    }
}
```
### Super Poderes
  São caracteriscas que se acoplam ao herói, podendo ser abundante ou não.
| Método     | Rota               | Descrição|
| :---       |:---                |:---|
| `POST`     | /registro          |  Registra um novo super poder          .|
| `GET`      | /heroi/todos       |  Busca todos as habilidades cadastradas.|
| `PUT`      | /heroi/editar      |  Edita um registro de poder            .|
| `DELETE`   | /heroi/remover/:id |  Remove cadastro por Id                .|
#### Exemplo:
```Json
{
  "id": 0,
  "nome": "string",
  "descricao": "string"
}
```
## Diagrama do banco de dados
![diagrama](https://raw.githubusercontent.com/GabriellPassos/assets/main/heroisapi/1.PNG)

## Tecnologias utilizadas
- C# .NET CORE, EF CORE
- FluentValidation
- MySQL

# Autor
[Gabriel Silva Passos](https://www.linkedin.com/in/gabrielsilvapassos/)

