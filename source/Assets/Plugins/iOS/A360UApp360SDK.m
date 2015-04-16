//
//  A360UApp360SDKWrapper.m
//  
//
//  Created by Tuan Tran Manh on 4/15/15.
//
//

#import "A360UApp360SDK.h"

#import <App360SDK/App360SDK.h>

@implementation A360UApp360SDK

- (id)initWithClient:(A360UTypeApp360SDKClientRef *)client
{
    self = [super init];
    if (self) {
        _client = client;
    }
    return self;
}

- (void)initialize:(NSString *)appId appSecret:(NSString *)appSecret
{
    [App360SDK initializeWithApplicationId:appId clientKey:appSecret block:^(MOGSession *session, NSError *error) {
        if (error) {
            //Error
            if (self.failureCallback) {
                self.failureCallback(self.client, [error.description UTF8String]);
            }
        } else {
            if (self.successCallback) {
                self.successCallback(self.client);
            }
        }
    }];
}

+ (NSString *)getChannel
{
    return [App360SDK getChannel];
}

+ (NSString *)getSubChannel
{
    return [App360SDK getSubChannel];
}

+ (NSString *)getSDKVersion
{
    return [App360SDK getSDKVersion];
}

@end
