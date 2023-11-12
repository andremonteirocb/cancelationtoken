# Laboratório Cancelationtoken
## Endpoint: sem-cancelation
### Cada request executado pelo usuário mesmo que o anterior não tenha sido finalizado irá adicionar uma pessoa a lista simulando assim um usuário inserido no banco

## Endpoint: com-cancelation
### Cada request executado pelo usuário irá cancelar o request anterior caso ele não tenha sido finalizado, com isso apenas um usuário será inserido ao final do processo
