# Exemplo de uso do cancelationtoken
## Endpoint: sem-cancelation
### Cada request executado pelo usu�rio mesmo que o anterior n�o tenha sido finalizado ir� adicionar uma pessoa a lista simulando assim um usu�rio inserido no banco

## Endpoint: com-cancelation
### Cada request executado pelo usu�rio ir� cancelar o request anterior caso ele n�o tenha sido finalizado, com isso apenas um usu�rio ser� inserido ao final do processo