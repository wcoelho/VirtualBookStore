# VirtualBookStoreApi
API para a gestão de uma livraria virtual. 

**Autores**  
* Walter Coelho
* Dalmo Melo

## Operações

* Postar comentários para livros (resenhas).  
* Pesquisa de livros por critérios diversos.  
* Manipular um carrinho de compras.  
* Realizar pedidos.  
* Acompanhamento o status das entregas realizadas.  
* Cadastrar livros.  

## Premissas/Implementações

* URIs baseadas em substantivos e no plural.  
=> books, reviews, carts, orders, deliveries.  
* URIs objetivas e simples, sem expor detalhes fisicos de implementação.  
=> Veja tópico "Endpoints"
* Utilização do PUT para atualização de dados.  
=> PATCH não foi utilizado.  
* Data e hora devem usar o padrão ISO 8601.  
=> Não utilizamos campos de data/hora
* Documentação em Swagger.  
=> Veja tópico "Documentação"
* Protocolo HTTPS/SSL e APIs versionadas.  
=> URL Base = https://localhost:5002/api/v1
* Paginação para coleções com grandes volumes de dados.  
=> Adicionados campos para controle de paginação para a entidade "book"
* Códigos de retorno adequados para cada método.  
=> Pode ser verificado durante a execução do Postman

## Arquitetura

![Arquitetura](Docs/arquitetura.jpg?raw=true "Arquitetura")

## Endpoints

**Consultas**  
_Método: GET_  

* /books = Recupera as informações de todos os livros cadastrados.  
* /books/{bookId} = Recupera as informações de um livro específico.  
* /books/{bookId}/reviews = Recupera todas as resenhas relativas a um livro específico.  
* /books/{bookId}/carts = Recupera todos carrinhos de compra que possuem um livro específico.  

* /reviews = Recupera todas as resenhas cadastradas.  
* /reviews/{reviewId} = Recupera uma resenha específica.  

* /carts = Recupera todos carrinhos de compra.  
* /carts/{cartId} = Recupera carrinho de compra específico.  

* /orders = Recupera todos os pedidos cadastrados.  
* /orders/{orderId} = Recupera um pedido específico.  

* /deliveries = Recupera todas as entregas registradas.
* /deliveries/{deliveryId} = Recupera uma entrega específica.

**Cadastros**  
_Método: POST_  

* /books  = Cadastra um livro.
* /reviews = Cadastra uma resenha.
* /carts = Cria um carrinho de compras.
* /orders = Cria um pedido de compra.
* /deliveries = Cria um controle de entrega de pedido.

**Atualizações**  
_Método: PUT_

* /books/{bookId} = Atualiza dados de um livro.
* /reviews/{reviewId} = Atualiza dados de uma resenha.
* /carts/{cartId} = Atualiza dados de um carrinho de compras.
* /orders/{orderId} = Atualiza dados de um pedido de compra.
* /deliveries/{deliveryId} = Atualiza um controle de entrega de pedido.

**Remoções**  
_Método: DELETE_

* /books/{bookId} = Apaga registro de um livro.
* /reviews/{reviewId} = Apaga registro de uma resenha.
* /carts/{cartId} = Apaga registro de um carrinho de compras.
* /orders/{orderId} = Apaga registro de um pedido de compra.
* /deliveries/{deliveryId} = Apaga registro de controle de entrega de pedido.  
  
## Validação de Usuário  
Durante a criação ou atualização de carrinho de compras e criação de pedido, os dados do usuário são validados através de chamada ao endpoint abaixo, consumindo a API "Authentication API":  
  
https://localhost:5001/api/v1/Authentication  
  
Código: [AuthenticationApi](https://github.com/wcoelho/AuthenticationApi)  
  

## Testes  
Importar a Postman Collection postman_collection.json e variáveis de ambiente postman_environment.json.

## Documentação  
Estando a aplicação em execução, acesse a seguinte URI:  
https://localhost:5002/swagger

