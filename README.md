## **RefitExample**
1. **[Get("/secure-posts")]**<br/>
Task<List<Post>> GetSecurePostsAsync([Header("Authorization")] string bearerToken);<br/>
Este método usa um cabeçalho HTTP para autenticação. O token de autenticação é passado diretamente como um parâmetro do método e é adicionado ao cabeçalho “Authorization” da requisição HTTP.

2. **[Get("/user-posts")]**<br/>
Task<List<Post>> GetUserPostsAsync([Authorize(scheme: "Bearer")] string token);<br/>
Este método usa o atributo [Authorize] do Refit, que é uma forma mais declarativa de especificar que a requisição deve ser autenticada usando o esquema “Bearer”. 
O token é passado como um parâmetro do método, mas o Refit gerencia a inclusão do token no cabeçalho “Authorization”.<br/>
##
