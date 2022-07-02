### Linguagem e Framework

A linguagem utilizada foi o C# com o framework .NET versão 6

[Download da SDK](https://dotnet.microsoft.com/en-us/download)

### Dados

    A aplicação está utilizando um banco de dados em memória com um carregamento de estudantes e cursos em sua inicialização.

### API Vídeos Vimeo

    Para autenticação na API é necessário adicionar no arquivo ‘src/Unisinos.Abc.Api/appsettings.json’ o ClientId e ClientSecret da aplicação criada no vimeo.

[Documentacao do Vimeo](https://developer.vimeo.com/pt-br)

### Aplicação

    Está habilitado em development o swagger onde é possível acessar pela rota ‘swagger/index.html’

<ul>
    <li>Através do método ‘GET’ na url ‘/Student’ é possível buscar todos estudantes cadastrados com seus cursos vinculados.</li>
    <li>Através do método ‘GET’ na url ‘/Student,{idStudent}/courses/{idCourse}’ é ´possível visualizar os vídeos vinculados ao curso específico</li>
    <li>Através do método ‘POST na url ‘/Student’ é possível cadastrar um novo estudante </li>
    <li>Através do método ‘GET’ na url ‘/Student,{idStudent}/courses/{idCourse}/bindcourse’ é possível vincular um curso ao estudante</li>
</ul>


### Comandos para rodar aplicação e testes

```sh

# Rodar a aplicação
dotnet run .\src\Unisinos.Abc.Api\

# Rodar os testes
dotnet test .\tests\Unisinos.Abc.Tests\

```
