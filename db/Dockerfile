FROM mcr.microsoft.com/mssql/server:2019-latest
# FROM mcr.microsoft.com/mssql/server:2019-CU12-ubuntu-20.04

ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=.Nv3rrefg049jsKK.

COPY SqlCmdScript.sql /docker-entrypoint-initdb.d/

EXPOSE 1433