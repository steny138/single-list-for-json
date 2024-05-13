# single-list-for-json

## Reason
解決json 的型別是 array type, 但實務上應只會回傳最多一個值

## Solution
利用自定義的`SingleList`型別，定義在 json class 的類型上
以此來定義該屬性只能回傳一個值

透過 `json converter` 的實作來實現觸發只能有一個值的限制。