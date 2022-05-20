import 'dart:convert';

List<UserInfoModel> userInfoModelFromJson(String str) => List<UserInfoModel>.from(json.decode(str).map((x) => UserInfoModel.fromJson(x)));

String userInfoModelToJson(List<UserInfoModel> data) => json.encode(List<dynamic>.from(data.map((x) => x.toJson())));


class UserInfoModel {
    UserInfoModel( {
        
        this.login,
        this.name,
        this.surname,
        this.photo
        
    });

    
    final String? login;
    final String? name;
    final String? surname;
    final String? photo;
    

    factory UserInfoModel.fromRawJson(String str) => UserInfoModel.fromJson(json.decode(str));

    String toRawJson() => json.encode(toJson());

    factory UserInfoModel.fromJson(Map<String, dynamic> json) => UserInfoModel(
        login: json["login"],
        name: json["name"],
        surname: json["surname"],
        photo: json["photo"],
        
    );

    Map<String, dynamic> toJson() => {
        "login": login,
        "name": name,
        "surname": surname,
        "photo": photo,
    };
}