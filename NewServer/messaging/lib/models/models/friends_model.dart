import 'dart:convert';

List<FriendsModel> userInfoModelFromJson(String str) => List<FriendsModel>.from(json.decode(str).map((x) => FriendsModel.fromJson(x)));

String userInfoModelToJson(List<FriendsModel> data) => json.encode(List<dynamic>.from(data.map((x) => x.toJson())));

class FriendsModel {
    FriendsModel({
        required this.secondUserId,
        required this.firstUserId,
    });

    int secondUserId;
    int firstUserId;

    factory FriendsModel.fromJson(Map<String, dynamic> json) => FriendsModel(
        secondUserId: json["SenderUserId"],
        firstUserId: json["AccepterUserId"],
    );

    Map<String, dynamic> toJson() => {
        "SenderUserId": secondUserId,
        "AccepterUserId": firstUserId,
    };
}