//
//  A360USessionManager.h
//  App360USDK
//
//  Created by Tuan Tran Manh on 4/15/15.
//  Copyright (c) 2015 Mwork. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "A360UTypes.h"

@interface A360USessionManager : NSObject

@property (nonatomic, assign) A360UTypeSessionManagerClientRef *client;

@property (nonatomic, assign) A360SessionSuccess successCallback;

@property (nonatomic, assign) A360SessionFailure failureCallback;

- (instancetype)initWithClient:(A360UTypeApp360SDKClientRef *)client;

- (void)createSessionWithScopedId:(NSString *)scopedId;

- (void)createSessionWithService:(NSString *)service token:(NSString *)token;

@end
