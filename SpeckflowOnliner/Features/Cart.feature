Feature: Cart

Scenario: Increase number of the product added to the cart
	Given User puts a product to the cart
	When The user proceeds to the cart
	And Increases the number of the product
	Then Product's price is changed respectively

Scenario: Delete the product added to the cart
	Given User has the product to buy
	When The product has been removed from the cart
	Then The cart no longer includes the product