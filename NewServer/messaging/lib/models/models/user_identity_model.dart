import 'dart:convert';

class UserIdentityModel {
  UserIdentityModel({
    this.login,
    this.password,
  });

  final String? login;
  final String? password;

  UserIdentityModel copyWith({
    String? nickname,
    String? password,
  }) =>
      UserIdentityModel(
        login: nickname ?? this.login,
        password: password ?? this.password,
      );

  factory UserIdentityModel.fromRawJson(String str) =>
      UserIdentityModel.fromJson(json.decode(str));

  String toRawJson() => json.encode(toJson());

  factory UserIdentityModel.fromJson(Map<String, dynamic> json) =>
      UserIdentityModel(
        login: json["login"],
        password: json["password"],
      );

  Map<String, dynamic> toJson() => {
        "login": login,
        "password": password,
      };
}