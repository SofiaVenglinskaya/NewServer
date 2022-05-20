import 'dart:convert';

List<UserInfoModel> userInfoModelFromJson(String str) => List<UserInfoModel>.from(json.decode(str).map((x) => UserInfoModel.fromJson(x)));

String userInfoModelToJson(List<UserInfoModel> data) => json.encode(List<dynamic>.from(data.map((x) => x.toJson())));


class UserInfoModel {
    UserInfoModel({
        this.id,
        this.nickname,
        this.name,
        this.email,
        this.description,
        this.linkInBio,
        this.medalsAmount,
        this.avatarUrl,
    });

    final int? id;
    final String? nickname;
    final String? name;
    final String? email;
    final String? description;
    final String? linkInBio;
    final int? medalsAmount;
    final String? avatarUrl;

    factory UserInfoModel.fromRawJson(String str) => UserInfoModel.fromJson(json.decode(str));

    String toRawJson() => json.encode(toJson());

    factory UserInfoModel.fromJson(Map<String, dynamic> json) => UserInfoModel(
        id: json["id"],
        nickname: json["nickname"],
        email: json["email"],
        name: json["name"],
        description: json["description"],
        linkInBio: json["linkInBio"],
        medalsAmount: json["medalsAmount"],
        avatarUrl: json["avatarUrl"],
    );

    Map<String, dynamic> toJson() => {
        "id": id,
        "nickname": nickname,
        "email": email,
        "name": name,
        "description": description,
        "linkInBio": linkInBio,
        "medalsAmount": medalsAmount,
        "avatarUrl": avatarUrl,
    };
}
