import 'package:dio/dio.dart';
import 'package:flutter/cupertino.dart';

import '../local_stoarge_service.dart';
import '../models/models/user_identity_model.dart';
import '../models/models/user_model.dart';
import 'action_result_generic (1).dart';
import 'models/current_user.dart';

class UserService {
  static Future<ActionResult<UserInfoModel>> registerUserApi(
      String login, String password) async {
    if (login.length < 2) {
      debugPrint("Ошибка валидации логина при авторизации");
      return ActionResult(
          data: null,
          statusCode: null,
          responseText: 'Логин должен состоять из более чем одного символа');
    }
    if (password.isEmpty) {
      debugPrint("Ошибка валидации пароля при авторизации");
      return ActionResult(
          data: null,
          statusCode: null,
          responseText: 'Пароль не должен быт пустым');
    }

    UserIdentityModel userIdentityModel =
        UserIdentityModel(login: login, password: password);
    String jsonUserIdenityModel = userIdentityModel.toRawJson();

    Map<String, dynamic> headers = {
      //ConfigApiService.microserviceApiKeyHeadName: ConfigApiService.microserviceApiKey,
      'Content-Type': 'aplication/json',
    };

    Dio dio =
        Dio(BaseOptions(headers: headers, responseType: ResponseType.json));

    try {
      Response<String> response = await dio.post(
          "http://localhost:52924/api/User/register",
          data: jsonUserIdenityModel);
      if (response.statusCode == 201) {
        String? responseBody = response.data;
        UserInfoModel user = UserInfoModel.fromRawJson(responseBody!);
        LocalStorageService.setUserData(
            currentUserLogin: login, currentUserPassword: password);
        CurrentUser.currentUser = user;

        return ActionResult(
            data: user,
            statusCode: response.statusCode,
            responseText: 'Добро пожаловать!');
      } else {
        debugPrint(
            'Ошибка ${response.statusCode} запроса при регистрации пользователя');
        return ActionResult(
            data: null,
            statusCode: response.statusCode,
            responseText: response.data);
      }
    } on DioError catch (e) {
      if (e.response != null) {
        debugPrint(e.response!.data);
        return ActionResult(
            data: null, statusCode: null, responseText: 'Что-то пошло не так');
      }
    }
    return ActionResult(
      data: null,
      statusCode: null,
      responseText: null
    );
  }

  static Future<ActionResult<UserInfoModel>> authUserApi(
      String login, String password) async {
    // //if (login.length < 2) {
    //   debugPrint("Ошибка валидации логина при авторизации");
    //   return ActionResult(
    //       data: null,
    //       statusCode: null,
    //       responseText: 'Логин должен состоять из более чем одного символа');
    // }
    // if (password.isEmpty) {
    //   debugPrint("Ошибка валидации пароля при авторизации");
    //   return ActionResult(
    //       data: null,
    //       statusCode: null,
    //       responseText: 'Пароль не должен быт пустым');
   // }

    UserIdentityModel userIdentityModel =
        UserIdentityModel(login: login, password: password);
    String jsonUserIdenityModel = userIdentityModel.toRawJson();

    Map<String, dynamic> headers = {
      //ConfigApiService.microserviceApiKeyHeadName: ConfigApiService.microserviceApiKey,
      'Content-Type': 'aplication/json',
    };

    Dio dio =
        Dio(BaseOptions(headers: headers, responseType: ResponseType.json));

    try {
      Response<String> response =
          await dio.post("http://localhost:52924/api/User/auth", data: jsonUserIdenityModel);
      if (response.statusCode == 200) {
        String? responseBody = response.data;
        UserInfoModel user = UserInfoModel.fromRawJson(responseBody!);
        LocalStorageService.setUserData(
            currentUserLogin: login, currentUserPassword: password);
        CurrentUser.currentUser = user;

        return ActionResult(
            data: user,
            statusCode: response.statusCode,
            responseText: 'Добро пожаловать!');
      } else {
        debugPrint(
            'Ошибка ${response.statusCode} запроса при регистрации пользователя');
        return ActionResult(
            data: null,
            statusCode: response.statusCode,
            responseText: response.data);
      }
    } on DioError catch (e) {
      if (e.response != null) {
        debugPrint(e.response!.data);
        debugPrint(e.message);
        return ActionResult(
            data: null, statusCode: null, responseText: 'Что-то пошло не так');
      }
    }
    return ActionResult(
      data: null,
      statusCode: null,
      responseText: null
    );
  }
}
