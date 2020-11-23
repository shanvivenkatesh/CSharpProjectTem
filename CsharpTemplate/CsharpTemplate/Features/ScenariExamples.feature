  
@filterPanelTestDevelopment  @regressionTests
Feature: FilterOrderByOrderStatus
    As distributor user i want to be able to filter Orders by Order status using filtering panel on order summary page


Background:
    Given User logged into Order UI


Scenario Outline: user can filter orders by status
    When User select order <Status> in order status filter
    Then user can see same <statusNumber> in the summary page


    Examples:
        | Status     | statusNumber |
        | Submitted  | 0            |
        | Sent       | 1            |
        | Received   | 2            |
        | In\ Repair | 3            |
        | Accepted   | 4            |
        | Priced     | 5            |
        | Duplicate  | 6            |
        | Invalid    | 7            |
        | Nacked     | 8            |
        | Rejected   | 9            |
 





