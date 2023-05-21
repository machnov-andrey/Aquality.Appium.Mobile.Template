Feature: Demo

@demo
Scenario: I check filters Cian
    When I log in in Cian with email '...' and password '...'
	When I choose rent
	When I fill in filters: house type - 'Комната', house size - '3'
	When I scroll down
	When I set price from '10000' to '30000' and set true owner check box
	Then Expected owner indicator, house type 'Комната' and price range '10000'-'30000'
	When I choose first offer
	Then Expected owner indicator, house type 'Комната', price range '10000'-'30000' and house size '3'
	When I click to show phone
	When I close Cian
