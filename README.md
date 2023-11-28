Utwórz aplikację ASP.NET Core 6/7. Nie musisz tworzyć interfejsu użytkownika!

Twoja aplikacja musi korzystać z kodu jednej z baz danych: MsSQL, MySQL, PostgreSQL (preferowane). Najpierw musisz użyć migracji kodu.

Model bazy danych musi być zaprojektowany do przechowywania następujących informacji:

Węzły drzew niezależnych. Każdy węzeł musi należeć do jednego drzewa. Wszystkie węzły podrzędne muszą należeć do tego samego drzewa, co ich węzeł nadrzędny. Każdy węzeł ma jedno pole obowiązkowe. To jest imię. Wszystko inne jest opcjonalne. Jeśli potrzebujesz czegoś do zaprojektowania niezależnych drzew, możesz to dodać, jak chcesz.
Dziennik wszystkich wyjątków podczas przetwarzania żądań REST API. Każdy rekord dziennika musi zawierać informacje o: unikalnym identyfikatorze zdarzenia, znaczniku czasu wystąpienia zdarzenia, wszystkich parametrach zapytania i treści oraz śladzie stosu wyjątku. Twoja aplikacja powinna udostępniać Rest API podobne (najlepiej takie same) do istniejącego (sprawdź swagger).
Twoja aplikacja powinna mieć własną klasę wyjątków „SecureException”. Jeżeli w trakcie przetwarzania żądania został zgłoszony wyjątek SecureException lub jego potomek, wszystkie informacje o wyjątku powinny zostać zapisane w dzienniku, a Twoja aplikacja powinna zwrócić odpowiedź ze statusem HTTP = 500. Odpowiedź powinna wyglądać następująco:

{"type": "nazwa wyjątku", "id": "id zdarzenia", "data": {"wiadomość": "komunikat wyjątku"}}

Przykład:

{"type": "Secure", "id": "638136064526554554", "data": {"message": "Najpierw musisz usunąć wszystkie węzły podrzędne"}}

Pełna informacja o wszystkich pozostałych typach wyjątków powinna być przechowywana w dzienniku. Jedyna różnica polega na tym, że odpowiedź dla innych typów wyjątków powinna wyglądać następująco:

{"type": "Wyjątek", "id": "id zdarzenia", "data": {"message": "Identyfikator wewnętrznego błędu serwera = identyfikator zdarzenia"}}

Przykład:

{"type": "Wyjątek", "id": "638136064187111634", "data": {"message": "ID wewnętrznego błędu serwera = 638136064187111634"}}



# ZetaProject

Create ASP.NET Core 6/7 application. You don't need creating UI!

Your application has to use code one of the databases: MsSQL, MySQL, PostgreSQL (preferred). You have to use code first migration.

The database model has to be designed for storing the following information:

1. Nodes of in-depended trees. Every node must belong to a single tree. All children nodes must belong to the same tree as their parent node. Every node has a single obligatory field. It is the name. Everything else is optional. If you need anything for designing in-depended trees you can add it as you want.
2. The journal of all exceptions during processing Rest API requests. Every journal record must keep information about: the unique event ID, the timestamp when the event happened, all query and body parameters, and the stack trace of an exception.
Your application should provide Rest API similar (ideally the same) to the existing (check swagger).

Your application should have its own "SecureException" exception class. If during the request processing SecureException or its child exception was thrown, all information about the exception should be stored in the journal and your application should return a response with HTTP status = 500. The response should look like this:

`{"type": "name of exception", "id": "id of event", "data": {"message": "message of exception"}}`

Example:

`{"type": "Secure", "id": "638136064526554554", "data": {"message": "You have to delete all children nodes first"}}`

The full information about all other exception types should be stored in the journal. The only difference is that the response for other exception types should look like:

`{"type": "Exception", "id": "id of event", "data": {"message": "Internal server error ID = id of event"}}`

Example:

`{"type": "Exception", "id": "638136064187111634", "data": {"message": "Internal server error ID = 638136064187111634"}}`
