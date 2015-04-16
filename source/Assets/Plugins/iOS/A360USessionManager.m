//
//  A360USessionManager.m
//  App360USDK
//
//  Created by Tuan Tran Manh on 4/15/15.
//  Copyright (c) 2015 Mwork. All rights reserved.
//

#import "A360USessionManager.h"
#import <App360SDK/App360SDK.h>

@implementation A360USessionManager

- (instancetype)initWithClient:(A360UTypeApp360SDKClientRef *)client
{
    self = [super init];
    if (self) {
        _client = client;
    }
    return self;
}

- (void)createSessionWithScopedId:(NSString *)scopedId
{
    [MOGSessionManager openActiveSessionWithScopeId:scopedId userInfo:nil block:^(MOGSession *session, NSError *error) {
        if (error) {
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

- (void)createSessionWithService:(NSString *)service token:(NSString *)token
{
    [MOGSessionManager openActiveSessionWithService:service token:token block:^(MOGSession *session, NSError *error) {
        if (error) {
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

@end
