# Price Calculation

Customer basket that allows a customer to add products and provides a total cost of the basket including applicable discounts. 

### Available products:

| Product | Cost  |
|---------|-------|
| Butter  | £0.80 |
| Milk    | £1.15 |
| Bread   | £1.00 |


### Offers:

- Buy 2 Butter and get a Bread at 50% off

- Buy 3 Milk and get the 4th milk for free

### Scenarios:

```
Given the basket has 1 bread, 1 butter and 1 milk 
When I total the basket 
Then the total should be £2.95

Given the basket has 2 butter and 2 bread 
When I total the basket 
Then the total should be £3.10

Given the basket has 4 milk 
When I total the basket 
Then the total should be £3.45

Given the basket has 2 butter, 1 bread and 8 milk 
When I total the basket 
Then the total should be £9.00
```


## Principles

- OOP / SOLID: Basic principles of structuring and writing the code.
- KISS: Not to over engineer when not needed.
- TDD: Adding functionality through testing
