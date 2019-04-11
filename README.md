# VirtualBookStoreApi
API para a gestão de uma livraria virtual.  

## Operações

* Postar comentários para livros (resenhas).  
* Pesquisa de livros por critérios diversos.  
* Manipular um carrinho de compras.  
* Realizar pedidos.  
* Acompanhamento o status das entregas realizadas.  
* Cadastrar livros.  

## Premissas

- PATCH não será utilizado
- URL Base = https://localhost:5001/api/v1

## Endpoints

**Consultas**  
_Método: GET_  

* /books = Recupera as informações de todos os livros cadastrados.  
* /books/{bookId} = Recupera as informações de um livro específico.  
* /books/{bookId}/reviews = Recupera todas as resenhas relativas a um livro específico.  
* /books/{bookId}/carts = Recupera todos carrinhos de compra que possuem um livro específico.  
* /books/{bookId}/orders = Recupera todas os pedidos relativos a um livro específico.  
* /books/{bookId}/deliveries = Recupera todas as entregas relativas a um livro específico. 


* /reviews = Recupera todas as resenhas cadastradas.  
* /reviews/{reviewId} = Recupera uma resenha específica.  

* /carts = Recupera todos carrinhos de compra.  
* /carts/{cartId} = Recupera carrinho de compra específico.  
* /carts/{cartId}/orders = Recupera pedidos efetuados para carrinho de compra específico.  

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

## Testes  
Importar a Postman Collection postman_collection.json e variáveis de ambiente postman_environment.json.

## Documentação  
https://localhost:5001/swagger
