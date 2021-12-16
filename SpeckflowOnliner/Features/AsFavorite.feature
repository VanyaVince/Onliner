Feature: FavoriteStar
	Simple calculator for adding two numbers

@mytag
Scenario: Mark an item as a favorite
	Given User logs into the system
	When The user looks for a specific item
	And Marks it as a favorite one
	Then The item is added to the favorite list