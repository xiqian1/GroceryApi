 ```
 GET: https://localhost:7161/api/grocery/
 ```
 
 ```
 RESPONSE:
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

```
PUT: https://localhost:7161/api/grocery/1
BODY:
{
    "itemid":"1",
    "itemname":"apple",
    "itemcategory":"fruit",
    "info":{
        "infoid":"1",
        "itemquantity":"15",
        "isavailable": true
    }
}
```

```
RESPONSE:
{
    "statusCode": 200,
    "statusDescription": "Grocery Item Updated",
    "grocery": {
        "itemId": 1,
        "itemName": "apple",
        "itemCategory": "fruit",
        "info": {
            "infoId": 1,
            "itemQuantity": 15,
            "isAvailable": true
        }
    }
}
```

```
POST: https://localhost:7161/api/grocery/
BODY:
{
    "itemname":"carrot",
    "itemcategory":"vegetable",
    "info":{
        "itemquantity":"30",
        "isavailable": true
    }
}
```

```
RESPONSE:
{
    "statusCode": 200,
    "statusDescription": "Grocery Item created",
    "grocery": {
        "itemId": 5,
        "itemName": "carrot",
        "itemCategory": "vegetable",
        "info": {
            "infoId": 5,
            "itemQuantity": 30,
            "isAvailable": true
        }
    }
}
```
