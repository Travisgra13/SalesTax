# ReadMe

I had to make some assumptions about the input that was given. The following are below:

## Assumptions

1. For each unique item name given, all entries with that name will have the price (If the item is imported, then it will be added as a different name). Example: Imported Book & Book are different items.
2. The shelf price is the same as the item's list price in the instructions.
3. Applied the same rounding metric to the Imported Tax as well as the Sales Tax.
4. Input 3's example output has a typo.  I think the line should've read (Imported Box of chocolates: 23.70 (2 @ 11.25)).
5. The user will input in the form:

```bash
for each item: QUANTITY ["IMPORTED"] ITEM_NAME "at" BASE_PRICE  
Followed by "done" when the user is done inputting item.
```

## Testing

1. Tests were run by attaching it to the .dll in the bin. Hopefully that is fine for your testing purposes.