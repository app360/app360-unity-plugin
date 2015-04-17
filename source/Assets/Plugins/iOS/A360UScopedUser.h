//
//  A360UScopedUser.h
//  App360USDK
//
//  Created by Tuan Tran Manh on 4/15/15.
//  Copyright (c) 2015 Mwork. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "A360UTypes.h"

@interface A360UScopedUser : NSObject

@property (nonatomic, assign) A360UTypeScopedUserClientRef *client;

@property (nonatomic, assign) A360UpdateUserSuccess successCallback;

@property (nonatomic, assign) A360UpdateUserFailure failureCallback;

- (instancetype)initWithClient:(A360UTypeScopedUserClientRef *)client;

+ (NSString *)getScopedId;

+ (NSString *)getChannel;

+ (NSString *)getSubChannel;

- (void)linkFacebookWithToken:(NSString *)token;

- (void)linkGoogleWithToken:(NSString *)token;

- (void)unlinkWithFacebook;

- (void)unLinkWithGoogle;

- (NSString *)getCurrentUser;

@end
