 ```
 GET: https://localhost:7161/api/grocery/
 ```
 ```
 {
    "statusCode": 200,
    "statusDescription": "Grocery Returned",
    "groceries": [
        {
            "itemId": 1,
            "itemName": "apple",
            "itemCategory": "fruit",
            "info": {
                "infoId": 1,
                "itemQuantity": 25,
                "isAvailable": true
            }
        },
        {
            "itemId": 2,
            "itemName": "milk",
            "itemCategory": "dairy",
            "info": {
                "infoId": 2,
                "itemQuantity": 17,
                "isAvailable": true
            }
        },
        {
            "itemId": 3,
            "itemName": "cherry",
            "itemCategory": "fruit",
            "info": {
                "infoId": 3,
                "itemQuantity": 50,
                "isAvailable": true
            }
        }
    ]
}
```
