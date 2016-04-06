var TodoListController = function ($scope, $http) {

    var desabilitarProcessando = function () {
        $scope.processando = null;
    }

    var habilitarProcessando = function () {
        $scope.processando = true;
    }

    var onGetAllComplete = function (response) {
        $scope.atividades = response.data;
        desabilitarProcessando();
    }

    var onErro = function (erroData) {
        $scope.mensagemErro = "Ooops, algo deu errado!";
        $scope.erro = erroData.data;
    }

    habilitarProcessando();
    var carregarRegistros = function () {
        $http.get("/api/Atividades")
                    .then(onGetAllComplete, onErro);
    }

    carregarRegistros();

    $scope.adicionar = function () {
        habilitarProcessando();
        var data = { "Titulo": $scope.formTitulo, "StatusConclusao": false };

        $http.post("/api/Atividades", JSON.stringify(data),
                {
                    headers: {
                        "Content-Type": "application/json"
                    }
                }
            ).success(function (dataRetorno) {
                $scope.atividades.push(dataRetorno);
                $scope.formTitulo = "";

            })
        .error(function (dataRetorno) {
            onErro(dataRetorno);
        })
            .finally(desabilitarProcessando);

    }

    $scope.atualizar = function ($event, titulo, id) {

        habilitarProcessando();

        var checkbox = $event.target;

        var data = { "Id": id, "Titulo": titulo, "StatusConclusao": checkbox.checked };

        $http.put("/api/Atividades/" + id, JSON.stringify(data),
                {
                    headers: {
                        "Content-Type": "application/json"
                    }
                }
            )
            .error(function (dataRetorno) {
            onErro(dataRetorno);
        })
            .finally(desabilitarProcessando);
    };

    $scope.excluir = function () {

        habilitarProcessando();

        var data = {};

        $http.delete("/api/Atividades", JSON.stringify(data),
                {
                    headers: {
                        "Content-Type": "application/json"
                    }
                }
            ).success(function () {
                carregarRegistros();
            })
        .error(function (dataRetorno) {
            onErro(dataRetorno);
        }).finally(desabilitarProcessando);
    };
}

app.controller("TodoListController", TodoListController);