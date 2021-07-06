# Moduit Backend - Coding Test

## Instructions

On this coding test, you need to create an **ASP.Net Core API** application solution to solve all the questions below.\
You can use any 3rd party library that is provided on **public** NuGet repository.

1. Please fork this project on branch **source**
2. After completing the tests, please push the code to your repository, notify and send your repository url to the examiner.

You need to connect with our screening API on this URL:

Base URL : https://screening.moduit.id/  
Swagger  : https://screening.moduit.id/swagger  

Note: _There's no authentication mechanism that you need to implement._

## 1. Question One

Please create a controller that sends request to this endpoint: **/backend/question/one** \
and please mirror **all** responses that you get from that endpoint.

Output Example:

```Json
{
  "id": 523329,
  "title": "Rustic Steel Salad",
  "description": "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit",
  "footer": "Ergonomic",
  "createdAt": "2021-06-28T17:56:03.7396771+00:00"
}
```

## 2. Question Two

Please create a controller that sends request to this endpoint: **/backend/question/two** \
then please apply the following filter to the response:
1. Description that contains "Ergonomics" or Title that contains "Ergonomics"
2. Tags that contains "Sports"
3. Order by Id descending
4. Get the last 3 (three) items only

Please put the resulting output from the above filter to the response.

## 3. Question Three

Please create a controller that sends request to this endpoint: **/backend/question/three** \
then please **flatten** property items from the response.

Input Example:

```Json
  {
    "id": 800728,
    "category": 4,
    "items": [
      {
        "title": "Incredible Steel Salad",
        "description": "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit",
        "footer": "Incredible"
      },
      {
        "title": "Practical Frozen Ball",
        "description": "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J",
        "footer": "Ergonomic"
      },
      {
        "title": "Sleek Cotton Pants",
        "description": "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit",
        "footer": "Handmade"
      }
    ],
    "createdAt": "2021-06-28T10:59:47.2135292+00:00"
  }
```

Output Example:
```Json
[
  {
    "id": 800728,
    "category": 4,
    "title": "Incredible Steel Salad",
    "description": "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit",
    "footer": "Incredible",
    "createdAt": "2021-06-28T10:59:47.2135292+00:00"
  },
  {
    "id": 800728,
    "category": 4,
    "title": "Practical Frozen Ball",
    "description": "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J",
    "footer": "Ergonomic",
    "createdAt": "2021-06-28T10:59:47.2135292+00:00"
  },
  {
    "id": 800728,
    "category": 4,
    "title": "Sleek Cotton Pants",
    "description": "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit",
    "footer": "Handmade",
    "createdAt": "2021-06-28T10:59:47.2135292+00:00"
  }
]
```

You have **24 hours** to complete all questions.

**Good Luck!**

