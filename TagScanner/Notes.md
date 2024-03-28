**Terms**

Class **Term** is the abstract base of the following hierarchy:

- ***Term*** *(abstract)*
  - **Constant**
  - **Field**
  - **Parameter**
  - ***Umptad*** *(abstract)*
    - **Cast**
    - **Function**
    - **Operation**

**Constant** represents any fixed value in an expression. Supported value types are *bool*, *char*, *string*, various numerical integer (*int*, *uint*, *long*, *ulong*) and floating point (*float*, *double*, *decimal*) formats, together with *TimeSpan* and *DateTime*.

**Field** represents any domain property. This system was developed to maintain the ID3 tags of a media collection, chiefly MP3 music files, so examples of fields are *Title*, *Duration*, *Album Title*, etc., or file properties such as *File Attributes*, or *File Created*. Notice that field names are permitted to contain spaces!

**Parameter** is used internally, to provide needed default parameters when building expressions manually.

**Umptad** 
