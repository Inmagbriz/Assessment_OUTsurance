Feature: DemoWebShop

Background:
	Given the user has navigated to 'https://demowebshop.tricentis.com/'


@demo
Scenario: S1 Login
	Given the user clicks Log in menu option
	When the user introduces 'amanda.fields@mail.com' in 'Email'
	And the user introduces 'amandafields' in 'Password'
	And the user clicks Log in button
	Then the user is logged in as 'amanda.fields@mail.com'

@demo
Scenario: S2 Checkout
	Given the user selects the catalogue 'books'
	And the user adds to cart the book
	And the user navigates to the Shopping cart
	And the user agrees with the terms of service
	When the user clicks Checkout button
	And the user is logged as 'amanda.fields@mail.com' with password 'amandafields'
	And the user clicks Continue in Billing Address
	And the user selects In-Store Pickup
	And the user clicks Continue in Shipping Address
	And the user clicks Continue in Payment Method
	And the user clicks Continue in Payment Information
	And the user confirms order
	Then the user gets the message an Order number