@shoppingCart
Feature: Shopping Cart
As a customer
I want to buy products online
So I can add products to my cart and checkout successfully

Background: 
	Given My usernme is 'standard_user'
	And my password is 'secret_sauce'
	And I am already login in my user account

@HappyPath 
Scenario: Buy a single item and complete checkout
	When I add to the cart the item 'Sauce Labs Backpack'
	And  I go the shopping cart
	And My product is in the cart
	And I enter my shipping information
	| Name       | Lupita   |
	| Last Name  | Carajada |
	| PostalCode | JKU 4566 |
	Then I should see the checkout overview has my purchase correctly
	And I comfirm the order
	And I should see the confirmation of my purchase 'Thank you for your order'
