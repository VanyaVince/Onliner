Feature: FavoriteItems
	user is able to mark items as favorites so that to be able to find them easily next time he/she logs in to the system

Scenario: Mark an item as a favorite
	Given User logs into the system
	When The user looks for a specific item
	And Marks it as a favorite one
	Then The item is added to the favorite list