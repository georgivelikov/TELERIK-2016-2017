1. What database models do you know?

Relational Model - The relational model is the best known and in today’s DBMS most often implemented database model. 
It defines a database as a collection of tables (relations) which contain all data. 
This module deals predominantly with the relational database model and the database systems based on it.

Object-oriented Model - Object-oriented models define a database as a collection of objects with features and methods.

Object-relational Model	- Object-oriented models are very powerful but also quite complex. With the relatively new object-relational database model is the wide spread and simple relational database model extended by some basic object-oriented concepts. These allow us to work with the widely know relational database model but also have some advantages of the object-oriented model without its complexity.

2. Which are the main functions performed by a Relational Database Management System (RDBMS)?

There are several functions that a DBMS performs to ensure data integrity and consistency of data in the database. The ten functions in the DBMS are: data dictionary management, data storage management, data transformation and presentation, security management, multiuser access control, backup and recovery management, data integrity management, database access languages and application programming interfaces, database communication interfaces, and transaction management.

3. Define what is "table" in database terms.

A table is a collection of related data held in a structured format within a database. It consists of columns, and rows.

4. Explain the difference between a primary and a foreign key.

The primary key consists of one or more columns whose data contained within is used to uniquely identify each row in the table. 
You can think of the primary key as an address.  If the rows in a table were mailboxes, then the primary key would be the listing 
of street addresses.

A foreign key is a set of one or more columns in a table that refers to the primary key in another table. 
There isn’t any special code, configurations, or table definitions you need to place to officially “designate” 
a foreign key.

5. Explain the different kinds of relationships between tables in relational databases.

A one-to-many relationship is the most common type of relationship. In this type of relationship, a row in table A can have many matching rows in table B, but a row in table B can have only one matching row in table A. For example, the publishers and titles tables have a one-to-many relationship: each publisher produces many titles, but each title comes from only one publisher.

In a many-to-many relationship, a row in table A can have many matching rows in table B, and vice versa. You create such a relationship by defining a third table, called a junction table, whose primary key consists of the foreign keys from both table A and table B. For example, the authors table and the titles table have a many-to-many relationship that is defined by a one-to-many relationship from each of these tables to the titleauthors table. The primary key of the titleauthors table is the combination of the au_id column (the authors table's primary key) and the title_id column (the titles table's primary key).

In a one-to-one relationship, a row in table A can have no more than one matching row in table B, and vice versa. A one-to-one relationship is created if both of the related columns are primary keys or have unique constraints. This type of relationship is not common because most information related in this way would be all in one table.

6. When is a certain database schema normalized?

Database normalization, or simply normalization, is the process of organizing the columns (attributes) and tables (relations) of a relational database to reduce data redundancy and improve data integrity.

7. What are database integrity constraints and when are they used?

Integrity constraints provide a mechanism for ensuring that data conforms to guidelines specified by the database administrator. The most common types of constraints include:

UNIQUE constraints - To ensure that a given column is unique

NOT NULL constraints - To ensure that no null values are allowed

FOREIGN KEY constraints - To ensure that two keys share a primary key to foreign key relationship

Constraints can be used for these purposes in a data warehouse:

Data cleanliness

Constraints verify that the data in the data warehouse conforms to a basic level of data consistency and correctness, preventing the introduction of dirty data.

Query optimization

8. Point out the pros and cons of using indexes in a database.

Indexes speed up SELECT's and slow down INSERT's.

9. What's the main purpose of the SQL language?

SQL is short for Structured Query Language. It is a standard programming language used in the management of data stored in a relational database management system. It supports distributed databases, offering users great flexibility.

10. What are transactions used for?

A transaction is a unit of work that is performed against a database. Transactions are units or sequences of work accomplished in a logical order, whether in a manual fashion by a user or automatically by some sort of a database program.

SQL> DELETE FROM CUSTOMERS
     WHERE AGE = 25;
SQL> COMMIT;

11. What is a NoSQL database?

A NoSQL (originally referring to "non SQL", "non relational" or "not only SQL")[1] database provides a mechanism for storage and retrieval of data which is modeled in means other than the tabular relations used in relational databases.

12. Explain the classical non-relational data models.

Key-value (KV) stores use the associative array (also known as a map or dictionary) as their fundamental data model. In this model, data is represented as a collection of key-value pairs, such that each possible key appears at most once in the collection.

The central concept of a document store is the notion of a "document". While each document-oriented database implementation differs on the details of this definition, in general, they all assume that documents encapsulate and encode data (or information) in some standard formats or encodings. Encodings in use include XML, YAML, and JSON as well as binary forms like BSON. Documents are addressed in the database via a unique key that represents that document. One of the other defining characteristics of a document-oriented database is that in addition to the key lookup performed by a key-value store, the database offers an API or query language that retrieves documents based on their contents.

This kind of database is designed for data whose relations are well represented as a graph consisting of elements interconnected with a finite number of relations between them. The type of data could be social relations, public transport links, road maps or network topologies.

An object database (also object-oriented database management system, OODBMS) is a database management system in which information is represented in the form of objects as used in object-oriented programming. Object databases are different from relational databases which are table-oriented. Object-relational databases are a hybrid of both approaches.

13. Give few examples of NoSQL databases and their pros and cons.

Key-Value Cache: Coherence, eXtreme Scale, GigaSpaces, GemFire, Hazelcast, Infinispan, JBoss Cache, Memcached, Repcached, Terracotta, Velocity
Key-Value Store: Flare, Keyspace, RAMCloud, SchemaFree, Hyperdex, Aerospike
Key-Value Store (Eventually-Consistent):	DovetailDB, Oracle NoSQL Database, Dynamo, Riak, Dynomite, MotionDb, Voldemort, SubRecord
Key-Value Store (Ordered):	Actord, FoundationDB, Lightcloud, LMDB, Luxio, MemcacheDB, NMDB, Scalaris, TokyoTyrant
Data-Structures Server:	Redis
Tuple Store: Apache River, Coord, GigaSpaces
Object Database: DB4O, Objectivity/DB, Perst, Shoal, ZopeDB
Document Store:	Clusterpoint, Couchbase, CouchDB, DocumentDB, IBM Domino, MarkLogic, MongoDB, Qizx, RethinkDB, XML-databases
Wide Column Store: BigTable, Cassandra, Druid, HBase, Hypertable, KAI, KDI, OpenNeptune, Qbase

