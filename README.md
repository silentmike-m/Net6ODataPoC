# Net 6 OData

## Run Locally

Clone the project
```bash
  git clone silentmike-m/Net6ODataPoC
```

Go to the project directory
```bash
  cd src
```

Build
```bash
  docker compose build
```

Start the server
```bash
  docker compose up
```

## Running Tests

#### Get all customers
```http
POST http://localhost:5080/Customers/GetCustomers
```

#### Get all customers ids
```http
POST http://localhost:5080/Customers/GetCustomers?$expand=customers($select=id)
```

#### Get all customers with tags and filtered by the first name contains 'Jam'
```http
POST http://localhost:5080/Customers/GetCustomers?$expand=customers($filter=contains(first_name, 'Jam');$expand=tags)
```

#### Get all customers without tags filtered by the firstname not contain 'Jam' and ordered by city DESC
```http
POST http://localhost:5080/Customers/GetCustomers?$expand=customers($filter=indexof(first_name, 'Jam') eq -1;$orderby=city desc)
```

#### Get all customers tags
```http
POST http://localhost:5080/Customers/GetCustomers?$expand=customers($expand=tags;$select=tags)
```

#### Get first 2 customers with tags ordered by city asc
```http
POST http://localhost:5080/Customers/GetCustomers?$expand=customers($expand=tags;$orderby=city;$top=2)
```

#### Get second 2 customers with tags ordered by city as
```http
POST http://localhost:5080/Customers/GetCustomers?$expand=customers($expand=tags;$orderby=city;$top=2;$skip=2)
```